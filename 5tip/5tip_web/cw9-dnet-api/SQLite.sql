-- SQLite
CREATE TABLE Sudents (
	id INTEGER PRIMARY KEY,
	firstname TEXT NOT NULL,
	lastname TEXT NOT NULL,
	age INTEGER NOT NULL,
	description TEXT
);

INSERT INTO Sudents (id, firstname, lastname, age, description) VALUES
	(1, 'Anna', 'Kowalska', 16, 'Lubi matematykę i czytanie.'),
	(2, 'Jan', 'Nowak', 17, 'Interesuje się programowaniem.'),
	(3, 'Maria', 'Wiśniewska', 15, 'Gra na gitarze.'),
	(4, 'Piotr', 'Wójcik', 18, 'Trenuje koszykówkę.'),
	(5, 'Katarzyna', 'Kamińska', 16, 'Lubi biologię.'),
	(6, 'Tomasz', 'Lewandowski', 17, 'Interesuje się historią.'),
	(7, 'Alicja', 'Zielińska', 15, 'Lubi rysować.'),
	(8, 'Michał', 'Szymański', 18, 'Gra w szachy.'),
	(9, 'Zofia', 'Woźniak', 16, 'Interesuje się chemią.'),
	(10, 'Paweł', 'Dąbrowski', 17, 'Lubi podróżować.');
