import { Button } from './components/Button';
import { H1 } from './components/HeaderElem';
import './style.css'

const app = document.querySelector<HTMLDivElement>("div");
if(app){
  //tutaj dodajemy komponenty do strony
  app.appendChild(H1("Jednak Łumiem","color:red") )
  const bt1 = Button("click me!!",20,100);
  app.appendChild(bt1);
  bt1.addEventListener("click",()=>{
    alert("hhhhh");
  });
}else{
  console.log("ERROR");
}




