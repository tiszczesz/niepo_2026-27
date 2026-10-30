<?php
function getConnection(): mysqli
{
    $conn = new mysqli("localhost", "root", null, "3tip_2026_contacts");
    if ($conn->connect_errno) {
        die($conn->connect_error);
    }
    return $conn;
}
function getPlaces(): array
{
    $conn = getConnection();
    $places = [];
    $sql = "SELECT * FROM places";
    $result = $conn->query($sql);
    while ($row = $result->fetch_assoc()) {
        $places[] = $row; //dopisanie nowego miejsca do tablicy
    }
    $conn->close();
    return $places;
}
function insertContact(array $contact): void
{
    $sql = "INSERT INTO mycontacts (firstname,lastname,phone,place_id) "
        . " VALUES('{$contact[0]}','{$contact[1]}','{$contact[2]}',{$contact[3]})";
    // echo $sql;
    $conn = getConnection();
    $conn->query($sql);
    $conn->close();
}
function getAllContacts(): array
{
    $conn = getConnection();
    $sql = "SELECT c.id,c.firstname, c.lastname, c.phone, p.name, place_id,p.description as description FROM mycontacts as c "
        . "INNER JOIN places as p  on p.id=c.place_id";
    $contacts = [];
    $result = $conn->query($sql);
    if ($result) {
        while ($row = $result->fetch_assoc()) {
            $contacts[] = $row;
        }
    }
    $conn->close();
    //var_dump($contacts);
    return  $contacts;
}
function getDescriptionById(int $id): string
{
    $conn = getConnection();
    $sql = "SELECT description FROM places WHERE id=$id";
    $result = $conn->query($sql);
    if($result){
        $description = $result->fetch_row()[0];
    }else{
        $description = "BRAK DANYCH";
    }
    $conn->close();
    return $description;
}
