<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>cw2 upload</title>
</head>
<body>
    <h1>Wysyłanie pbrazków na serwer</h1>
    <form action="result.php" method="post" enctype="multipart/form-data">
        <label for="fileUpload">wybierz plik do przesłania</label>
        <input type="file" name="fileUpload" id="fileUpload">
        <button type="submit">Prześlij plik</button>
    </form>
</body>
</html>