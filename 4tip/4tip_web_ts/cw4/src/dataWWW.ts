export function generInput():HTMLInputElement{
    const input =  document.createElement("input");
    input.type = "number";
    input.id = "number"
    return input;
} 
export const generButton = (content:string) => {
    const button = document.createElement("button");
    button.textContent = content;    
}
export function generList(type: "ul" | "ol",count:number)
       :HTMLUListElement | HTMLOListElement{

  const list =  document.createElement(type)
  for(let i=0; i<count;i++){
    const option = document.createElement("option");
    option.textContent = `element numer; ${i+1}`;
    list.appendChild(option)
  }
  return list;
}