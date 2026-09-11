<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <h1>Ćwiczenie 4</h1>
    <h3>Pętle w php</h3>
    <h5>Pętla for(;;)</h5>
    <?php
    for ($i = 1; $i <= 6; $i++) {
        echo "<h$i>To jest nagłówek h$i</h$i>";
    }
    ?>
    <h5>Pętla while() {...}</h5>
    <?php
    $sum = 0;
    //stała w php
    //define("MAX", 100); stare podejście
    const MAX = 100; //nowe podejście
    while ($sum < MAX) {
        //generuje losową liczbę z przedziału 1-10
        $random = rand(1, 10);
        $sum += $random; // $sum = $sum + $random;
        echo $random . " "; //sklejona liczba ze SPACJĄ
    }
    echo "<br> Suma wylosowanych liczb wynosi: $sum";
    ?>

    <h5>Pętla do {...} while()</h5>
    <?php
    //$sum = 0;
    $counter = 0;
    //suma, srednia, min, max, ile liczb wylosowano zanim wylosowano 0
    const CONDITION = 0;
    do {
        $random = rand(0, 20);
        if ($random !== CONDITION) {
            $counter++;
        }
        echo "$random ";
    } while ($random != CONDITION);
    echo "<br> Wylosowano $counter liczb zanim wylosowano: "
        . CONDITION;
    ?>
</body>

</html>