# Hook `useEffect` — przykłady

`useEffect` pozwala uruchamiać efekty uboczne w komponencie React, na przykład timer albo zmianę tytułu strony. Hook wywołujemy na najwyższym poziomie komponentu, a nie wewnątrz warunków czy pętli.

## Zegar

Komponent wyświetla aktualny czas i odświeża go co sekundę:

```jsx
import { useEffect, useState } from "react";

function Zegar() {
  const [czas, setCzas] = useState(() => new Date());

  useEffect(() => {
    const timerId = setInterval(() => {
      setCzas(new Date());
    }, 1000);

    return () => clearInterval(timerId);
  }, []);

  return <p>Aktualny czas: {czas.toLocaleTimeString()}</p>;
}

export default Zegar;
```

Pusta tablica zależności `[]` oznacza, że efekt uruchamia się po zamontowaniu komponentu. Funkcja zwrócona z efektu sprząta po nim — tutaj zatrzymuje timer, gdy komponent zostanie odmontowany. Dzięki temu nie pozostaje działający interwał.

## Aktualizacja tytułu strony

Efekt może też synchronizować tytuł karty przeglądarki z wartością w komponencie:

```jsx
import { useEffect, useState } from "react";

function Powitanie() {
  const [imie, setImie] = useState("Ada");

  useEffect(() => {
    document.title = `Witaj, ${imie}!`;
  }, [imie]);

  return (
    <label>
      Imię: <input value={imie} onChange={(event) => setImie(event.target.value)} />
    </label>
  );
}

export default Powitanie;
```

Tablica `[imie]` oznacza, że efekt uruchamia się po pierwszym wyświetleniu komponentu oraz ponownie za każdym razem, gdy zmieni się `imie`. W tym przykładzie sprzątanie nie jest potrzebne, bo efekt nie tworzy timera ani subskrypcji — po prostu ustawia tytuł strony.

## Podsumowanie

- Bez drugiego argumentu efekt uruchamia się po każdym renderze.
- Z pustą tablicą `[]` efekt uruchamia się po zamontowaniu komponentu.
- Z tablicą zależności, np. `[imie]`, efekt uruchamia się po zamontowaniu i po zmianie podanych wartości.
- Jeśli efekt tworzy timer, subskrypcję lub inne zasoby, zwróć funkcję sprzątającą, która je usuwa.
