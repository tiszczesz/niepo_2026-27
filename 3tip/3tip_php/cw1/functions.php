<?php
function getConnection() : mysqli {
    $conn = new mysqli("localhost","root",null,"3tip_2026_contacts");
    if($conn->connect_errno){
        die($conn->connect_error);
    }
    return $conn;
}
function getPlaces() : array {
    $conn = getConnection();
    $places = [];
    $sql = "SELECT * FROM places";
    $result = $conn->query($sql);
    while($row = $result->fetch_assoc()){
        $places[] = $row; //dopisanie nowego miejsca do tablicy
    }
    $conn->close();
    return $places;
}