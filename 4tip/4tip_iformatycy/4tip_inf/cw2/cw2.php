<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="cw2.css">
    <title>Document</title>
</head>

<body>
    <h1>Przykłady echo</h1>
    <section>
        <div>Użycie typów</div>
        <?php
        //jezyk php jest słabo typowany, nie trzeba deklarować typu zmiennej
        $a = 5;
        $text = "Ala ma kota";
        echo "Hello World!  zmienna a = $a \n<br>";
        echo "Hello World!  zmienna a = {$a} \n<br>";
        echo 'Hello World!  zmienna a = $a \n<br>';
        echo 'Hello World!  zmienna a = ' . $a .  "\n" . '<br>';
        echo 'Hello World!  zmienna a = {$a} \n<br>';
        print "Hello World! print zmienna a = $a \n<br>";
        var_dump($a);
        echo get_debug_type($a), "\n";
        $a = 45.9;
        var_dump($a);
        $a = true;
        var_dump($a);
        ?>
    </section>
    <section>
        <div>Przykłady typów</div>
        <?php
        $a_bool = true;   // a bool
        $a_str  = "foo";  // a string
        $a_str2 = 'foo';  // a string
        $an_int = 12;     // an int

        echo get_debug_type($a_bool), "\n";
        echo get_debug_type($a_str), "\n";

        // If this is an integer, increment it by four
        if (is_int($an_int)) {
            $an_int += 4;
        }
        var_dump($an_int);

        // If $a_bool is a string, print it out
        if (is_string($a_bool)) {
            echo "String: $a_bool";
        }
        ?>
    </section>
    <section>
        <div>Operatory: </div>
        <?php
        $a = 5;
        $b = 10;
        echo "a = $a, b = $b \n<br>";
        echo "$a + $b = " . ($a + $b) .  "\n<br>";
        echo "$a - $b = " . ($a - $b) . "\n<br>";
        echo "$a * $b = " . ($a * $b) . "\n<br>";
        //użycie instrukcji warunkowej if do sprawdzenia dzielenia przez zero
        if ($b === 0) {
            echo "$a / $b = DZIELENIE PRZEZ ZERO\n<br>";
        } else {
            echo "$a / $b = " . ($a / $b) . "\n<br>";
        }
        //użycie operatora ?
        echo "$a / $b = " . ($b !== 0 ? ($a / $b) : "DZIELENIE PRZEZ ZERO") . "\n<br>";

        ?>
    </section>
</body>

</html>