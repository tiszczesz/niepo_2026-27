<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
    include "functions.php";
    //Show_DIR_FILE();
    const filename = "dane.txt";
    //const filename = "cw11.php";
    $f = fopen(filename,'r');
    $lines = [];
    //var_dump($f);
    while($line = trim(fgets($f))){
       $lines[] = $line;
    }
    
    if($f) fclose($f);

    // zapis do pliku
    $txt = ["sad sadsad ad ","dsf dsfsd fsdfs","ala ma kota"];
    $f = fopen("output.txt",'w');
    foreach($txt as $l){
        fwrite($f,$l.PHP_EOL);
    }
    if($f) fclose($f);
    var_dump($lines);
    ?>
</body>
</html>