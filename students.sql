CREATE TABLE Students (
    id INTEGER PRIMARY KEY,
    firstname TEXT NOT NULL,
    lastname TEXT NOT NULL,
    division TEXT NOT NULL,
    description TEXT
);

INSERT INTO Students (id, firstname, lastname, division, description) VALUES
    (1, 'Anna', 'Kowalska', '1A', 'Interesuje się matematyką.'),
    (2, 'Jan', 'Nowak', '1A', 'Lubi grać w piłkę nożną.'),
    (3, 'Maria', 'Wiśniewska', '1B', 'Uczy się języka hiszpańskiego.'),
    (4, 'Piotr', 'Wójcik', '1B', 'Interesuje się programowaniem.'),
    (5, 'Zofia', 'Kowalczyk', '2A', 'Lubi czytać książki.'),
    (6, 'Kacper', 'Kamiński', '2A', 'Gra na gitarze.'),
    (7, 'Julia', 'Lewandowska', '2B', 'Interesuje się biologią.'),
    (8, 'Jakub', 'Zieliński', '2B', 'Trenuje pływanie.'),
    (9, 'Maja', 'Szymańska', '3A', 'Lubi fotografię.'),
    (10, 'Antoni', 'Woźniak', '3A', 'Interesuje się historią.'),
    (11, 'Hanna', 'Dąbrowska', '3B', 'Uczestniczy w kole teatralnym.'),
    (12, 'Franciszek', 'Kozłowski', '3B', 'Lubi rozwiązywać zagadki.'),
    (13, 'Alicja', 'Jankowska', '4A', 'Interesuje się chemią.'),
    (14, 'Szymon', 'Mazur', '4A', 'Gra w szachy.'),
    (15, 'Oliwia', 'Kwiatkowska', '4B', 'Lubi rysować.'),
    (16, 'Filip', 'Krawczyk', '4B', 'Interesuje się elektroniką.'),
    (17, 'Laura', 'Piotrowska', '5A', 'Uczy się języka niemieckiego.'),
    (18, 'Mikołaj', 'Grabowski', '5A', 'Trenuje koszykówkę.'),
    (19, 'Natalia', 'Pawłowska', '5B', 'Interesuje się astronomią.'),
    (20, 'Adam', 'Michalski', '5B', 'Lubi podróżować.');
