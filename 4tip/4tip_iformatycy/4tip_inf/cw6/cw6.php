<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Arrays</title>
</head>

<body>

    <h1>Tablice w php</h1>

    <h3>Tablice indeksowane liczbami całkowitymi</h3>
    <?php
    $nazwaTablicy = []; //zdefiniowanie tablicy
    $nazwaTablicy2 = array(3, 6, 7, 90); //zdefiniowanie tablicy stary sposób
    var_dump($nazwaTablicy);
    var_dump($nazwaTablicy2);
    $nazwaTablicy[] = "gggg"; // dodaj na koniec tablicy js g.push("ggggg")
    var_dump($nazwaTablicy);
    $nazwaTablicy[] = [5, 8, 23];
    //$nazwaTablicy = [5, 8, 23]; nadpisanie tablicy
    $nazwaTablicy[] = "ala ma kota";
    var_dump($nazwaTablicy);
    $nazwaTablicy[1] = "juz nie ma liczb!!!!";
    var_dump($nazwaTablicy);
    $nazwaTablicy[] = 99;
    $nazwaTablicy[] = 200;
    var_dump($nazwaTablicy);
    //dziurawienie tablicy
    unset($nazwaTablicy[2]);
    var_dump($nazwaTablicy);
    //echo $nazwaTablicy[2];
    //nie powinno sie uzywac pętli for do tablicy bo moze miec dziury, lepiej foreach
    // for ($i = 0; $i < count($nazwaTablicy); $i++) {
    //     echo $nazwaTablicy[$i] . "<br>";
    // }
    //petla foreach
    foreach ($nazwaTablicy as $elem) {
        echo $elem . "<br>";
    }
    ?>
    <h3>Tablice asoscjacyjne - zbiór par klucz-wartość</h3>
    <?php
    $assocTab = [
        "k1" => "zaawrtosc k1",
        "ff" => 34
    ];
    $assocTab["first"] = "zawartość pierwszego elementu";
    $assocTab[] = "po pushu";
    var_dump($assocTab);

    $kolory = [
        "red" => "czerwony",
        "green" => "zielony",
        "blue" => "niebieski",
        "yellow" => "żółty",
        "black" => "czarny",
        "white" => "biały",
        "orange" => "pomarańczowy",
        "purple" => "fioletowy",
        "pink" => "różowy",
        "brown" => "brązowy"
    ];
    var_dump($kolory);
    echo "<select>";
    foreach ($kolory as $ang => $pol) {
        echo "<option value=$ang>$pol</option>\n";
    }
    echo "</select>";
    ?>
</body>

</html>