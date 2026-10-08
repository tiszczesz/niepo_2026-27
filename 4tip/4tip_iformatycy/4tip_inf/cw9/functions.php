<?php

function getClassName(): string
{
    $classList = [
        "1A",
        "1B",
        "1C",
        "2A",
        "2B",
        "2C",
        "3A",
        "3B",
        "3C"
    ];
    $html = "";
    foreach ($classList as $c) {
        $html .= "\t<option value='{$c}'>{$c}</option>\n";
    }
    return $html;
}
function getHobby(): string
{
    $hobbies = [
        "Sport",
        "Książki",
        "Muzyka",
        "Taniec",
        "Nauka",
        "Kino"
    ];
    $html = "";
    foreach ($hobbies as $h) {
        $html .= "<label>{$h}</label>\n";
        $html .= "<input type='checkbox' name='hobbies[]' value='{$h}'><br>\n";
    }
    return $html;
}
