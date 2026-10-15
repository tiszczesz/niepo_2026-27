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
            <input type="text" name="firstname" id="firstname" required>
        </div>
        <div class="row">
            <label for="lastname">Podaj nazwisko</label>
            <input type="text" name="lastname" id="lastname" required>
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
            <label for="male">Mężczyzna</label>
            <input type="radio" name="gender" id="male" value="Mężczyzna"><br>
            <label for="female">Kobieta</label>
            <input type="radio" name="gender" id="female" value="Kobieta" checked><br>
            <label for="other">Inna</label>
            <input type="radio" name="gender" id="other" value="Inna"><br>
        </div>
        <div class="row">
            <input name="submit" type="submit" value="Zatwierdź">
        </div>

    </form>
    <hr>

    <?php
    if (isset($_POST['submit'])) {
        echo "<h3>Wynik działania formularza</h3>";
        $firstname = trim($_POST['firstname']);
        $lastname = trim($_POST['lastname']);
        $classname = $_POST['classname'];
        if (isset($_POST['hobbies'])) {
            $is_hobbies = true;
            $hobbies = $_POST['hobbies'];
        } else {
            $is_hobbies = false;
            $hobbies = "Brak zainteresowań";
        }
        $gender = $_POST['gender'];
        echo "<div class='result'>\n";
        echo "<p>Imię: {$firstname} Nazwisko: {$lastname} płeć: {$gender}</p>\n";
        echo "<p>Zapisany do klasy: {$classname}</p>\n";
        if ($is_hobbies) {
            echo "<p>Zainteresowania:</p>\n";
            echo "<ul>\n";
            foreach ($hobbies as $h) {
                echo "\t<li>{$h}</li>\n";
            }
            echo "</ul>\n";
        } else {
            echo "<p>$hobbies</p>\n";
        }
        //var_dump($_POST);
        //echo "<p>Imię: {$firstname}</p>\n";
        echo "</div>\n";
    } else {
        // echo "<p>TO nie SUBMIT POST!!!</p>";
    }

    ?>
</body>

</html>