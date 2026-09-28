<!DOCTYPE html>
<html lang="pl">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styl.css">
    <title>Gry komputerowe</title>
</head>

<body>
    <header>
        <h1>Ranking gier komputerowych</h1>
    </header>
    <main>
        <section class="left">
            <h3>Top 5 gier w tym miesiącu</h3>
            <ul>
            <?php
            require_once 'functions.php';
            $topGames = getTopGames();
            foreach ($topGames as $game){
                echo "<li> {$game['nazwa']} <span class='points'>{$game['punkty']}</span></li>";
            }
            ?>
            </ul>
            <h3>Nasz sklep</h3>
            <a href="http://sklep.gry.pl">Tu kupisz gry</a>
            <h3>Stronę wykonał</h3>
            <p>XXXXXXXXX</p>
        </section>
        <section class="middle">
            <?php
            //skrypt 2
            ?>
        </section>
        <section class="right">
            <h3>Dodaj nową grę</h3>
            <form action="" method="post">
                <label for="name">Nazwa</label>
                <input type="text" name="name" id="name"><br>
                <label for="price">cena</label>
                <input type="number" name="price" id="price"><br>
                <label for="picture">Zdjęcie</label>
                <input type="text" name="picture" id="picture"><br>
                <input type="submit" value="Dodaj">
            </form>
        </section>
    </main>
    <footer>
        <form action="" method="post">
            <input type="text" name="description" id="description">
            <input type="submit" value="Pokaż opis">            
        </form>
        <?php
        //skrypt 3
        ?>
    </footer>
</body>

</html>