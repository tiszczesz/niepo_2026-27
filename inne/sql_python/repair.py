import os
import shutil
import sys

# Systemowe bazy danych MySQL – nie są kopiowane z data_old
SYSTEM_DATABASES = {"mysql", "performance_schema", "information_schema", "sys"}


def find_xampp_mysql():
    candidates = [
        r"C:\xampp\mysql",
        r"D:\xampp\mysql",
        r"C:\XAMPP\mysql",
    ]
    for path in candidates:
        if os.path.isdir(path):
            return path
    return None


def run_repair(mysql_dir: str):
    data_dir = os.path.join(mysql_dir, "data")
    data_old_dir = os.path.join(mysql_dir, "data_old")
    backup_dir = os.path.join(mysql_dir, "backup")

    # Krok 1 – sprawdzenie folderów
    print(f"[1] Folder MySQL:  {mysql_dir}")
    if not os.path.isdir(data_dir):
        print(f"    BŁĄD: Nie znaleziono folderu {data_dir}")
        sys.exit(1)
    if not os.path.isdir(backup_dir):
        print(f"    BŁĄD: Nie znaleziono folderu {backup_dir}")
        sys.exit(1)

    # Krok 2 – zmień nazwę starego data → data_old, utwórz nowy data
    print(f"[2] Zmiana nazwy '{data_dir}' → '{data_old_dir}'")
    if os.path.exists(data_old_dir):
        print(f"    Folder data_old już istnieje – usuwam poprzedni...")
        shutil.rmtree(data_old_dir)
    os.rename(data_dir, data_old_dir)
    os.makedirs(data_dir)
    print(f"    Utworzono nowy folder: {data_dir}")

    # Krok 3 – z data_old skopiuj bazy użytkowników i ibdata1
    print("[3] Kopiowanie baz użytkowników i ibdata1 z data_old do data...")
    for entry in os.listdir(data_old_dir):
        src = os.path.join(data_old_dir, entry)

        # ibdata1 – plik
        if entry == "ibdata1" and os.path.isfile(src):
            dst = os.path.join(data_dir, entry)
            shutil.copy2(src, dst)
            print(f"    Skopiowano plik:    {entry}")
            continue

        # Foldery z bazami użytkowników (nie systemowe)
        if os.path.isdir(src) and entry.lower() not in SYSTEM_DATABASES:
            dst = os.path.join(data_dir, entry)
            shutil.copytree(src, dst)
            print(f"    Skopiowano bazę:    {entry}/")

    # Krok 4 – z backup skopiuj wszystko oprócz ibdata1
    print("[4] Kopiowanie zawartości backup → data (bez ibdata1)...")
    for entry in os.listdir(backup_dir):
        if entry == "ibdata1":
            print(f"    Pomijam:            {entry}")
            continue
        src = os.path.join(backup_dir, entry)
        dst = os.path.join(data_dir, entry)
        if os.path.isdir(src):
            shutil.copytree(src, dst, dirs_exist_ok=True)
            print(f"    Skopiowano folder:  {entry}/")
        else:
            shutil.copy2(src, dst)
            print(f"    Skopiowano plik:    {entry}")

    # Krok 5
    print("[5] Gotowe! Uruchom ponownie MySQL w XAMPP.")
    print("    Jeśli nadal nie działa – uruchom skrypt jeszcze raz.")


if __name__ == "__main__":
    if len(sys.argv) > 1:
        mysql_dir = sys.argv[1]
    else:
        mysql_dir = find_xampp_mysql()

    if mysql_dir is None:
        mysql_dir = input("Podaj ścieżkę do folderu mysql XAMPP: ").strip()

    if not os.path.isdir(mysql_dir):
        print(f"BŁĄD: Folder nie istnieje: {mysql_dir}")
        sys.exit(1)

    run_repair(mysql_dir)
