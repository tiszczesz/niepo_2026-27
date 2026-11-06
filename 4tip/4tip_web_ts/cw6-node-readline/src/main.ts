import * as readline from "node:readline/promises";

//cout i cin z c++
const rdl: readline.Interface = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});
const firstname = await rdl.question("Podaj imię: ");
const age = parseInt(await rdl.question("Podaj wiek: "));
const age2 = Number(await rdl.question("Podaj wiek: "));
console.log(age2);

if (age2 < 18) {
  console.log("niepelnoletni");
} else {
  console.log("pelnoletni");
}
rdl.close();
console.log(firstname);
