<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">

    <link rel="stylesheet" href="cw1.css">
    <title>Kontakty</title>
</head>

<body>

    <header>
        <?php
        include_once "nav.php";
        ShowNav();
        ?>
    </header>
    <main class="container">
        <h1>Dodaj nowy kontakt</h1>
        <form action="addContact.php" method="post">
            <div class="row mt-2">
                <label class="col-3 text-end" for="firstname">Imię</label>
                <input type="text" class="col-6" id="firstname" name="firstname" required>
                <span class="col-3 text-danger"></span>
            </div>
            <div class="row mt-2">
                <label class="col-3 text-end" for="lastname">Nazwisko</label>
                <input type="text" class="col-6" id="lastname" name="lastname" required>
                <span class="col-3 text-danger"></span>
            </div>
            <div class="row mt-2">
                <label class="col-3 text-end" for="phone">Telefon</label>
                <input type="text" class="col-6" id="phone" name="phone" required>
                <span class="col-3 text-danger"></span>
            </div>
                <div class="row mt-2">
                <label class="col-3 text-end" for="place">Krąg</label>
                <select name="place" id="place" class="col-6">
                    <?php
                    //wczytanie miejsc z bazy danych
                    require_once "functions.php";
                    $places = getPlaces();
                  //  var_dump($places);
                  foreach($places as $p){
                    echo "<option value=\"{$p['id']}\">{$p['name']}</option>\n";
                  }
                    ?>
                </select>
            </div>
            <div class="row mt-2">
                <input type="submit" value="Dodaj kontakt" class="btn btn-primary offset-3 col-6">
            </div>
        </form>
    </main>
    <?php
    ShowFooter();
    ?>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>

</html>