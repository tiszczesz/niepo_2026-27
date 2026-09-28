export type Contact = {
    id:number;
    firstname:string;
    lastname:string;
    phone:string
}
export const contacts:Contact[] = [
    { id: 1, firstname: "Anna", lastname: "Kowalska", phone: "501-234-567" },
    { id: 2, firstname: "Piotr", lastname: "Nowak", phone: "502-345-678" },
    { id: 3, firstname: "Katarzyna", lastname: "Wiśniewska", phone: "503-456-789" },
    { id: 4, firstname: "Michał", lastname: "Wójcik", phone: "504-567-890" },
    { id: 5, firstname: "Julia", lastname: "Kamińska", phone: "505-678-901" },
    { id: 6, firstname: "Tomasz", lastname: "Lewandowski", phone: "506-789-012" },
    { id: 7, firstname: "Magdalena", lastname: "Zielińska", phone: "507-890-123" },
    { id: 8, firstname: "Paweł", lastname: "Szymański", phone: "508-901-234" },
    { id: 9, firstname: "Natalia", lastname: "Dąbrowska", phone: "509-012-345" },
    { id: 10, firstname: "Jakub", lastname: "Kozłowski", phone: "510-123-456" }
]