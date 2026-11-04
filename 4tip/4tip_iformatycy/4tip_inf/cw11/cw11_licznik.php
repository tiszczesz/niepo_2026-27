<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Strona z licznikiem odwiedzin</h1>
    <section>
        <?php
        $counter = 0;
        const FILE_NAME = "counter.txt";
        if(file_exists(FILE_NAME)){
            $f = fopen(FILE_NAME,'r');
            if($f){
                $counter = intval(fgets($f));
                fclose($f);
            }            
        }
       $counter++;
        echo "Ilość odwiedzin: {$counter}";        
        $f = fopen(FILE_NAME,'w');
        if($f) {
            fwrite($f,$counter);
            fclose($f);
            }
        ?>
        
    </section>
    <section>
        <a href="reset.php">Zresetuj licznik</a>
    </section>
</body>
</html>