<?php
function getConnection(): mysqli
{
    $conn = new mysqli("localhost", "root", null, '3tip_2026_gry');
    if ($conn->connect_error) {
        die("Błąd połączenia: " . $conn->connect_error);
    }
    return $conn;
}
function getTopGames():array //zwraca tablicę z top 5 gier bez html
{
    $conn = getConnection();
    $sql = "SELECT nazwa, punkty FROM `gry` ORDER BY punkty DESC LIMIT 5";
    $result = $conn->query($sql);
    if(!$result) {
        return [];
    }
    $games = [];
    while($row = $result->fetch_assoc()){
        $games[] = $row;
    }
    
    $conn->close();
    return $games;
}