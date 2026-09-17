<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ćwiczenie 5 - strings</title>
</head>
<body>
   <h2>ćwiczenie 5 - strings</h2>
    <?php
    $text = "ala ma kota";
    $textPL = "żółta ściana";
    echo $text;
    echo "<p>napis $text ilość znaków: " . strlen($text) . "</p>";
    echo "<p>napis $textPL ilość znaków: " . mb_strlen($textPL) . "</p>";
    ?>
    <h3>Odwracanie napisów</h3>
    <?php
    echo "<p>odwrócony napis $text: " . strrev($text) . "</p>";
    //ręcznie odwracanie napisów
    $reversedText = "";
    for($i = strlen($text) - 1; $i >= 0; $i--){ //od końca do początku
        $reversedText .= $text[$i];
    }
    echo "<p>odwrócony napis $text (ręcznie): " . $reversedText . "</p>";
    ?>
    <h3>Odwracanie napisów polskich</h3>
    <?php
    echo "<p>odwrócony napis $textPL: " . strrev($textPL) . "Brak odpowiednika mb_strrev</p>";
    //ręcznie odwracanie napisów
    $reversedText = "";
    for($i = mb_strlen($textPL) - 1; $i >= 0; $i--){ //od końca do początku
        $reversedText .= mb_substr($textPL, $i, 1);
    }
    echo "<p>odwrócony napis $textPL (ręcznie): " . $reversedText . "</p>";
    ?>
    <h3>Zadanie napis w pionie ASCII a potem znaki PL </h3>
</body>
</html>