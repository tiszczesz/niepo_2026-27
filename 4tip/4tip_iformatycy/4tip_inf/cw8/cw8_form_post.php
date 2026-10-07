<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ćwiczenie 8</title>
</head>

<body>
    <h1>Formuarz wysłany metodą post</h1>
    <form action="cw8_result.php" method="post">
        <input type="number" name="count" id="count" style="width:200px"
            min="0" max="1000" step="1" required
            placeholder="Podaj ile liczb">
        <input name="submit" type="submit" value="Wygeneruj">
    </form>
</body>

</html>