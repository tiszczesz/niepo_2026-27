import { movies, type Movie } from "./data.js";

const root = document.querySelector<HTMLDivElement>("#root");
if (root !== null) {
  const h1 = showHeaderH1();
  const tab = showTab(movies);
  root.appendChild(h1);
  root.appendChild(tab);
}

function showHeaderH1(): HTMLHeadingElement {
  const h1 = document.createElement("h1");

  h1.textContent = "Lista filmów";
  return h1;
}
function showTab(data: Movie[]): HTMLTableElement {
  const tab = document.createElement("table");
  let lp = 0;
  tab.classList.add("table", "table-striped");
  const theaad = document.createElement("thead");
  const tr = document.createElement("tr");
  tr.innerHTML = `<th>Lp</th>
                    <th>Tytuł</th>
                    <th>Reżyser</th>
                    <th>Rodzaj</th>
                    <th>Rok</th>`;
  theaad.appendChild(tr);
  tab.appendChild(theaad);
  const tbody = document.createElement("tbody");
  for(const elem of data){
    const tr = document.createElement("tr");
    tr.innerHTML = `<td>${++lp}</td>
                    <td>${elem.title}</td>
                    <td>${elem.director}</td>
                    <td>${elem.genre}</td>
                    <td>${elem.year}</td>
                    `;
    tbody.appendChild(tr);
  }
  tab.appendChild(tbody);
  //todo
  return tab;
}
