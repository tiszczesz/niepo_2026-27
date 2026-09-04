<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Pętla for(;;)</h1>
    <section>
        <?php
        for ($i = 0; $i < 10; $i++) {
            echo "Hello World!  zmienna i = $i \n<br>";
        }
        ?>
    </section>
    <section>
        Wygeneruj w php listę numerowaną html od 1 do 100 z napisem "element listy nr i"
        <?php
        echo "<ol>";
        for ($i = 1; $i <= 100; $i++) {
            echo "<li>element listy nr $i</li>";
        }
        echo "</ol>";
        ?>
    </section>
</body>
</html>