<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <title>Document</title>
</head>
<body>
    <h1>Liczby pierwsze</h1>
    <h3>Sprawdź czy to liczba pierwsza</h3>
    <?php
    $value = 0;
    if(isset($_POST['prime'])){
            $value = intval($_POST['prime']);
        }
    ?>
    <form method="post">
        <input type="number" min="2" placeholder="Podaj liczbę" name="prime"
        value="<?php echo $value;?>"  >
        <button type="submit">Sprawdź czy pierwsza?</button>
    </form>   
        <?php
        include "functions.php";
        if(isPrime($value)){
            echo "<div class='green'>Liczba {$value} jest pierwsza</div>";
        }else{
            echo "<div class='red'>Liczba {$value} nie jest pierwsza</div>";
        }
        ?>
    
</body>
</html>