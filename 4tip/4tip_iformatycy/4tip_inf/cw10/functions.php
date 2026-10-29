<?php
function isPrime(int $number) : bool {
    //sprawdzanie czy $number jest liczba pierwsza
    //w pętli srawdzacie  czy reszta z dzielenia $number przez liczby od 2 do $number jest równa 0
    if($number<2) return false;
    for($i=2;$i * $i <= $number;$i++){
        if($number % $i === 0) return false;
    }
    return true;
}