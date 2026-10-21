const root = document.querySelector<HTMLDivElement>("#root");
if(root!==null){
    const h1 = document.createElement("h1");
    h1.textContent = "Lista filmów";
    root.appendChild(h1);
}