import { names, isPrime } from "./functions.js";
import { createInterface } from "node:readline/promises";
const rl = createInterface({
  input: process.stdin,
  output: process.stdout,
});
   let q = 'k';
do {
  q = await rl.question("podaj liczbę: (k - koniec) ");
  if (q[0]?.toLowerCase() == "k") break;
  const number = parseInt(q);
  if (!isNaN(number)) {
    console.log(isPrime(number) ? "liczba pierwsz" : "nie liczba pierwsza");
  } else {
    console.log("to nie liczba");
  }
} while (q[0] !== "k");
rl.close();
//console.log(names);
