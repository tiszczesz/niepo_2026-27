<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="cw13.css">
    <title>Mysqli - łączenie</title>
</head>
<body>
    <pre>
    <?php
    $conn = new mysqli("localhost","root",null,"4tip_2026_inf1");
    var_dump($conn);
    if($conn->connect_errno!=0){
        die("Błąd połączenia z MYSQL");
    }
    $sql = "SELECT * FROM games";

    //wykonanie zapytania w php mysqli query
    $result = $conn->query($sql);
    var_dump($result);
    //wyłuskanie danych z $result fetch_...
    $data = $result->fetch_all();
    echo "<table>\n";
    echo "<tr>\n<th>id</th><th>tytuł</th><th>rodzaj</th><th>cena</th><th>rok</th></tr>";
    foreach($data as $row){
        echo "<tr>\n";
        echo "\t<td>{$row[0]}</td>\n";
        echo "\t<td>{$row[1]}</td>\n";
        echo "\t<td>{$row[2]}</td>\n";
        echo "\t<td class='right'>{$row[3]}</td>\n";
        echo "\t<td class='right'>{$row[4]}</td>\n";
        echo "</tr>";
    }
    echo "</table>";
    ?>
    </pre>
</body>
</html>