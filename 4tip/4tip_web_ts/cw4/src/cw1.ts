// const section = document.createElement("section");
// section.textContent = "ala ma kota";
// document.body.appendChild(section);
import { generButton,generList,generInput } from "./dataWWW.js";
const input = generInput();
const button = generButton("Generuj listę");
document.body.appendChild(input);
document.body.appendChild(button);
button.addEventListener("click",()=>{
    console.log(input.value);
    const list = generList("ul",parseInt(input.value));
    document.body.appendChild(list);
});
