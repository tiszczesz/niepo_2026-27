<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <link rel="stylesheet" href="cw1.css">
    <title>Kontakty</title>
</head>

<body>

    <header>
        <?php
        include_once "nav.php";
        ShowNav();
        ?>
    </header>
    <main class="container d-flex gap-4">
        <section>
            <h1>Lista kontaktów</h1>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Lp</th>
                        <th>Imię</th>
                        <th>Nazwisko</th>
                        <th>Telefon</th>
                        <th>Miejsce</th>
                    </tr>
                </thead>
                <tbody>
                    <?php
                    require_once "functions.php";
                    $result = getAllContacts();
                    $lp = 0;
                    foreach ($result as $c) {
                        $lp++;
                        echo "<tr>\n";
                        echo "\t<td>{$lp}</td>\n";
                        echo "\t<td>{$c['firstname']}</td>\n";
                        echo "\t<td>{$c['lastname']}</td>\n";
                        echo "\t<td>{$c['phone']}</td>\n";
                        echo "\t<td><a href='list.php?id={$c['place_id']}'>{$c['name']}</a></td>\n";
                        echo "</tr>\n";
                    }
                    ?>
                </tbody>



            </table>
        </section>
        <section class="mt-5">
            <?php
            if (isset($_GET['id'])) {
                $id = intval($_GET['id']);
                echo "<div>".getDescriptionById($id)."</div>";
            }
            ?>

        </section>
    </main>
    <?php
    ShowFooter();
    ?>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>

</html>