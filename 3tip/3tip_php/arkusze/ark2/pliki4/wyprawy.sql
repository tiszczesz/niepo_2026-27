-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 16 Sty 2025, 12:47
-- Wersja serwera: 10.4.22-MariaDB
-- Wersja PHP: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `wyprawy`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rezerwacje`
--

CREATE TABLE `rezerwacje` (
  `id` int(10) UNSIGNED NOT NULL,
  `Wycieczki_id` int(10) UNSIGNED NOT NULL,
  `imie` varchar(20) COLLATE utf8_polish_ci DEFAULT NULL,
  `nazwisko` varchar(20) COLLATE utf8_polish_ci DEFAULT NULL,
  `osob` int(10) UNSIGNED DEFAULT NULL,
  `wylot` varchar(15) COLLATE utf8_polish_ci DEFAULT NULL,
  `wyzywienie` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `rezerwacje`
--

INSERT INTO `rezerwacje` (`id`, `Wycieczki_id`, `imie`, `nazwisko`, `osob`, `wylot`, `wyzywienie`) VALUES
(1, 1, 'Anna', 'Nowakowska', 2, 'Warszawa', 3),
(2, 1, 'Karolina', 'Kowalska', 1, 'Kraków', 2),
(3, 1, 'Jan', 'Konieczny', 2, 'Kraków', 3),
(4, 2, 'Monika', 'Zawada', 2, 'Wrocław', 1),
(5, 2, 'Judyta', 'Kowalewska', 4, 'Warszawa', 3),
(6, 2, 'Piotr', 'Nowak', 1, 'Kraków', 1),
(7, 2, 'Jan', 'Zabłocki', 1, 'Warszawa', 1),
(8, 2, 'Grzegorz', 'Nowak', 2, 'Kraków', 2),
(9, 3, 'Anna', 'Kowalska', 2, 'Kraków', 1),
(10, 3, 'Jolanta', 'Kowal', 2, 'Wrocław', 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wycieczki`
--

CREATE TABLE `wycieczki` (
  `id` int(10) UNSIGNED NOT NULL,
  `miejsce` varchar(10) COLLATE utf8_polish_ci DEFAULT NULL,
  `cenaPodstawowa` int(10) UNSIGNED DEFAULT NULL,
  `opis` text COLLATE utf8_polish_ci DEFAULT NULL,
  `maxOsob` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `wycieczki`
--

INSERT INTO `wycieczki` (`id`, `miejsce`, `cenaPodstawowa`, `opis`, `maxOsob`) VALUES
(1, 'Barcelona', 1500, '', 12),
(2, 'Rzym', 1500, '', 20),
(3, 'Londyn', 1500, '', 20);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `rezerwacje`
--
ALTER TABLE `rezerwacje`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Wycieczki_id` (`Wycieczki_id`);

--
-- Indeksy dla tabeli `wycieczki`
--
ALTER TABLE `wycieczki`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `rezerwacje`
--
ALTER TABLE `rezerwacje`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT dla tabeli `wycieczki`
--
ALTER TABLE `wycieczki`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `rezerwacje`
--
ALTER TABLE `rezerwacje`
  ADD CONSTRAINT `rezerwacje_ibfk_1` FOREIGN KEY (`Wycieczki_id`) REFERENCES `wycieczki` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
