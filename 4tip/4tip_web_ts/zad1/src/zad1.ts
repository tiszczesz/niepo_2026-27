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
  return tab;
}
