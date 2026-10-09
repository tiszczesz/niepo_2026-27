const todos = [
	{id:1,content:"Odpisać na ważne wiadomości",isDone:false},
    {id:2,content:"Posprzątać biurko",isDone:false},
    {id:3,content:"Zrobić zakupy",isDone:false},
    {id:4,content:"Przygotować obiad",isDone:false},
    {id:5,content:"Wynieść śmieci",isDone:false},
    {id:6,content:"Podlać rośliny",isDone:false},
    {id:7,content:"Ułożyć plan na jutro",isDone:false},
    {id:8,content:"Przeczytać rozdział książki",isDone:false},
    {id:9,content:"Wykonać trening",isDone:false},
    {id:10,content:"Położyć się spać przed 23:00",isDone:false}
]
function getLastId(data){
    let lastId = 0;
    data.forEach(element => {
        if(element.id > lastId){
            lastId = element.id
        }
    });
    return lastId;
}
function FillTodos(id, data){
    const elem = document.querySelector("#"+id);
    let html = "<ol id='todoList'>";
    for(const todo of data){
        html += `<li>${todo.content} <button id='${todo.id}'>x</button></li>\n`;
    }
    html += "</ol>"
    elem.innerHTML = html ;
    //elem.id = "todoList";
    const allLi = document.querySelectorAll("#todoList li");
    for(const button of allLi){
        //ustawic na przycisku click
    }
    console.log(allLi);
}
FillTodos("result",todos);
document.querySelector("#todo").addEventListener("input",(event)=>{
    console.log(event.target.value.length>0);
    document.querySelector("#btnAdd").disabled = event.target.value.trim().length === 0 
})
//zad1 wygeneruj listę ol z powyższymi zadaniami do div o id result
document.querySelector("#btnAdd").addEventListener("click",()=>{
    const todoInput = document.querySelector("#todo");
    //const newTodo = todoInput.value.trim();
    //dodanie do array
   // todos.push(newTodo);
    todos.push({id:getLastId(todos)+1,content:todoInput.value.trim(),isDone:false});
    //odswiezenie listy
    FillTodos("result",todos);
    todoInput.value = "";
    console.log(todos);
});
//usuniecie z array
//update listy na stronie FillTodos("result",todos);