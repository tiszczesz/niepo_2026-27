export const Button = (content:string,height:number=15,width:number=60):HTMLButtonElement =>{
    //todo
    const button = document.createElement<"button">("button");
    button.textContent = content;
    button.style.width = `${width}px`;
    button.style.height = `${height}px`;
    return button;
};