<?php
if(isset($_POST['lastname'])){
    //var_dump($_POST);
    $firstname = htmlspecialchars($_POST['firstname']);
    $lastname = htmlspecialchars($_POST['lastname']);
    $phone = htmlspecialchars($_POST['phone']);
    $place = intval(htmlspecialchars($_POST['place']));
   // $place = filter_var(INPUT_POST,'place',FILTER_VALIDATE_INT)
    //validacja na serwerze
    if(!empty($firstname) && !empty($lastname) && !empty($phone)){
        //insert do DB
    }
   // $lastname = filter_input(INPUT_POST,'lastname',FILTER_SANITIZE_SPECIAL_CHARS);
}else{
    echo "TO NIE SUBMIT";
}
// if(filter_has_var(INPUT_POST,'lastname')){

// }
// if($_SERVER['REQUEST_METHOD']==='POST'){

// }