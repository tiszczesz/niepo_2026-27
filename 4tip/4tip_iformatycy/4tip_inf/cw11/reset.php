<?php
const FILE_NAME = "counter.txt";
if(file_exists(FILE_NAME)){
    unlink(FILE_NAME);
}
header("Location: cw11_licznik.php");