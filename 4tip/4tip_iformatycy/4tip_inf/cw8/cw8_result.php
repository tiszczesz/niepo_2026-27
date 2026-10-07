<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <h1>Wynik działania formularza</h1>
    <?php
    //var_dump($_POST);
    if (isset($_POST['submit'])) {
        $count = intval($_POST['count']);

        if ($count < 1) {
            echo "Brak danych!!!!";
            exit;
        }
        echo "<table style='border-collapse:collapse'>";
        echo "<tr>";
        echo "<th>a</th><th>a<sup>2</sup></th><th>a<sup>3</sup></th>";
        echo "</tr>";
        for ($i = 1; $i < $count; $i++) {
            echo "<tr>";
            echo "<td style='text-align: right; border:solid 1px black; padding: 10px'>{$i}</td>";
            echo "<td style='text-align: right; border:solid 1px black; padding: 10px'>"
                . ($i * $i) . "</td>";
            echo "<td style='text-align: right; border:solid 1px black; padding: 10px'>"
                . ($i * $i * $i) . "</td>";
            echo "</tr>";
        }

        echo "</table>";
    } else {
        header("Location: cw8_form_post.php");
    }

    ?>
</body>

</html>