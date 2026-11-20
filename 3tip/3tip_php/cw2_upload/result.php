<?php
var_dump($_FILES);
// var_dump(__FILE__);
// var_dump(__DIR__);
$target_dir = __DIR__.'/uploads/';
$target_file = $target_dir.basename($_FILES['fileUpload']['name']);
var_dump($target_file);
//zaczynamy walidacje pliku
$no_error_upload = 1;
//typ pliku
$fileType = strtolower(string: pathinfo(
    path: $target_file,
    flags: PATHINFO_EXTENSION
));
var_dump($fileType);
// var_dump(pathinfo(
//     path: $target_file,
//     flags:PATHINFO_EXTENSION
// ));
echo "<p>typ pliku: {$fileType}</p>";
//sprawdzenie czy plik jest obrakiem
$check = getimagesize(filename: $_FILES['fileUpload']['tmp_name'] );
var_dump($check);
if($check!==false){
    echo "<p>Plik jest obrazkim - ".$check['mime']."</p>";
    $no_error_upload = 1;
}else{
    echo "<p>Plik nie jest obrazkim - </p>";
    $no_error_upload = 0;
}

//sprawdzenie czy taki plik już jest
if(file_exists($target_file)){
    echo "<p>Plik już istnieje</p>";
    $no_error_upload = 0;
}
//rozmiar pliku
if($_FILES['fileUpload']['size'] > 5_000_000){
    echo "<p>obrazek za duży</p>";
}
//format obrazka
if($fileType != "jpg" && $fileType != "png" && $fileType != "jpeg"
    && $fileType != "gif"
){
    echo "Dozwolone sa tylko pliki JPG, JPEG, PNG i GIF.<br>";
    $no_error_upload = 0;
}
if($no_error_upload == 0){
    echo "<p>Plik nie został wgrany z powodu błędów</p>";
}else{
    if(move_uploaded_file(
        from: $_FILES['fileUpload']['tmp_name'],
        to: $target_file
    )){
        echo "<p>Plik  został wgrany na serwer</p>";
        var_dump(scandir($target_dir));
    }
}