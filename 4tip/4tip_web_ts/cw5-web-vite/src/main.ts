import { H1 } from './components/HeaderElem';
import './style.css'

const app = document.querySelector<HTMLDivElement>("div");
if(app){
  //tutaj dodajemy komponenty do strony
  app.appendChild(H1("Jednak Łumiem","color:red") )
}




