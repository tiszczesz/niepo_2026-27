<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="cw9.css" />
    <title>Formularz zgłoszeniowy</title>
</head>

<body>
    <h1>Formularz zgłoszeniowy</h1>
    <form method="post">
        <div class="row">
            <label for="firstname">Podaj imię</label>
            <input type="text" name="firstname" id="firstname">
        </div>
        <div class="row">
            <label for="lastname">Podaj nazwisko</label>
            <input type="text" name="lastname" id="lastname">
        </div>
        <div class="row">
            <label for="classname">Wybierz klasę</label>
            <select name="classname" id="classname">
               <?php
               require_once "functions.php";
               echo getClassName();
               ?> 
            </select>
        </div>
        <div class="row">
            <?php
            echo getHobby();
            ?>
        </div>
        <div class="row">
            <input type="submit" value="Zatwierdź">
        </div>

    </form>
    <hr>

    <?php
    if (isset($_POST['firstname'])) {
        echo "<h3>Wynik działania formularza</h3>";
        $firstname = trim($_POST['firstname']);
        echo "<p>Imię: {$firstname}</p>\n";
    } else {
        echo "<p>TO nie SUBMIT POST!!!</p>";
    }

    ?>
</body>

</html>