export type Movie = {
    id: number;
    title:string;
    director:string;
    genre:string;
    year:number
}
export const movies: Movie[] = [
    { id: 1, title: "Cień nad rzeką", director: "Anna Kowalska", genre: "Dramat", year: 2020 },
    { id: 2, title: "Ostatni przystanek", director: "Marek Nowak", genre: "Thriller", year: 2018 },
    { id: 3, title: "Gwiezdny ogród", director: "Julia Wiśniewska", genre: "Sci-fi", year: 2022 },
    { id: 4, title: "Letni deszcz", director: "Piotr Zieliński", genre: "Romans", year: 2019 },
    { id: 5, title: "Tajemnica starego domu", director: "Ewa Kamińska", genre: "Kryminał", year: 2021 },
    { id: 6, title: "Wielka wyprawa", director: "Tomasz Lewandowski", genre: "Przygodowy", year: 2017 },
    { id: 7, title: "Miasto świateł", director: "Katarzyna Wójcik", genre: "Komedia", year: 2023 },
    { id: 8, title: "Pod powierzchnią", director: "Adam Dąbrowski", genre: "Horror", year: 2016 },
    { id: 9, title: "Droga do domu", director: "Magdalena Szymańska", genre: "Familijny", year: 2024 },
    { id: 10, title: "Echo przeszłości", director: "Paweł Woźniak", genre: "Historyczny", year: 2020 }
]