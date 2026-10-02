<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <h2>Tablice superglobalne w PHP</h2>
    <pre>
        <h6>$_ENV</h6>
    <?php
    var_dump($_ENV);
    ?>
    <h6>$_SERVER</h6>
    <?php
    var_dump($_SERVER);
    ?>
     <h6>$_POST</h6>
    <?php
    var_dump($_POST);
    ?>
     <h6>$_REQUEST</h6>
    <?php
    var_dump($_REQUEST);
    ?>
     <h6>$_SESSION</h6>
    <?php
    if (isset($_SESSION)) {
        var_dump($_SESSION);
    } else {
        echo "BRAK SESJI";
    }
    ?>
     <h6>$_GET</h6>
    <?php
    var_dump($_GET);
    ?>
    </pre>
</body>

</html>