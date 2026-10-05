import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { contacts, getNextId, type Contact } from './data/contacts';
import { useState } from 'react';

function App() {
  const [mycontacts, setMyContacts] = useState<Contact[]>(contacts);
  const [contactToEdit,setContactToEdit] = useState<Contact>({
    id:-1,
    firstname:"",
    lastname:"",
    phone:""
  })
  const [isEdit,setIsEdit] = useState(false);
  console.log(mycontacts);
  
  function handleDelete(id: number): void {
    const contactsAfterDelete = mycontacts.filter(c => c.id !== id);
    setMyContacts(contactsAfterDelete);
  }
  function handleAction(formData:FormData):void{
    //console.log("akcja");
    //console.log(formData);
    if(!isEdit){
      const firstname = formData.get("firstname")?.toString()??"";
      const lastname = formData.get("lastname")?.toString()??"";
      const phone = formData.get("phone")?.toString()??"";
      const newContact:Contact = {
        id:getNextId(mycontacts),
        firstname,
        lastname,
        phone
      }
      setMyContacts([...mycontacts,newContact]);  
      //czyszczenie formularza
      setContactToEdit({
        id:-1,
        firstname:"",
        lastname:"",
        phone:""
      })
      
    }else{
      //reakcja na update
      const id = Number(formData.get("id")?.toString()??"-1");
      const firstname = formData.get("firstname")?.toString()??"";
      const lastname = formData.get("lastname")?.toString()??"";
      const phone = formData.get("phone")?.toString()??"";

      const updatedContact:Contact = {
        id,
        firstname,
        lastname,
        phone
      }
      const updatedContacts = mycontacts.map(c => c.id === id ? updatedContact : c);
      setMyContacts(updatedContacts);
      setIsEdit(false)
    }
  }

  function handleUpdate(id: number): void {
    const toEdit = mycontacts.find((c)=>c.id===id)
    if(toEdit){
      setContactToEdit(toEdit)
      setIsEdit(true)
    }

    //alert("updatowanie kontaktu o id: "+id)
  }

  return (
    <>
      <header><h1>Lista kontaktów</h1></header>
      <main className='d-flex gap-3'>
        <section>
          <h5>Tabelka z kontaktami</h5>
          <table className='table table-striped' style={{ minWidth: "400px" }}>
            <thead>
              <tr>
                <th>Imię</th>
                <th>Nazwisko</th>
                <th>Telefon</th>
                <th> --- </th>
              </tr>
            </thead>
            <tbody>
              {mycontacts.map(contact => (
                <tr key={contact.id}>
                  <td>{contact.firstname}</td>
                  <td>{contact.lastname}</td>
                  <td>{contact.phone}</td>
                  <td>
                    <button
                      className='btn btn-outline-danger'
                      onClick={() => handleDelete(contact.id)}
                    >Usuń</button>
                    &nbsp;
                    <button 
                    className='btn btn-outline-secondary'
                    onClick={()=>handleUpdate(contact.id)}
                    >Edytuj</button>
                  </td>
                </tr>
              )
              )}
            </tbody>
          </table>
        </section>
        <section><h5 className='mb-2'>{!isEdit ?"Dodanie nowego kontaku":"Edycja kontaktu"}</h5>
        <form className='mt-4' action={handleAction}>
          <div className="mt-2">
            <label htmlFor="firstname" 
                >Imię</label>
                <input type="hidden" name="id" value={contactToEdit.id} />
            <input type="text" name="firstname" id="firstname" value={contactToEdit.firstname}
            onChange={(event)=>setContactToEdit({...contactToEdit, firstname: event.target.value})}
             className="form-control" />
          </div>
           <div className="mt-2">
            <label htmlFor="lastname" 
               >Nazwisko</label>
            <input type="text" name="lastname" id="lastname"
            value={contactToEdit.lastname}
            onChange={(event)=>setContactToEdit({...contactToEdit, lastname: event.target.value})}
             className="form-control" />
          </div>
           <div className="mt-2">
            <label htmlFor="phone" 
               >Telefon</label>
            <input type="text"  id="phone" name='phone'
            value={contactToEdit.phone}
            onChange={(event)=>setContactToEdit({...contactToEdit, phone: event.target.value})}
             className="form-control" />
          </div>
          <div className="mt-2">
            <button type='submit' className="btn btn-outline-primary w-100">{!isEdit ? "Dodaj kontakt":"Zapisz zmiany"}</button>
          </div>
        </form>
        </section>
      </main>
      <footer>&copy; 2026 Alojzy Gąbka</footer>
    </>
  )
}

export default App
