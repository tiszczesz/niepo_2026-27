<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Data</title>
</head>

<body>
    <?php
    echo date("Y-m-d h:i:s",  strtotime("2023-12-03"));
    echo "<p>Ile sekund od 1970-01-01: " . strtotime("2023-12-03") . "</p>";
    $dd = new DateTime();
    $a = 34.89;
    echo "<pre>";
    var_dump($dd);
    var_dump($a);
    echo "</pre>";
    echo "<p>DateTime: " . $dd->format("Y-m-d") . "</p>";
    ?>
</body>

</html>