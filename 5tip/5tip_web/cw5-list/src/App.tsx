import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { contacts, getLastId, type Contact } from './data/contacts';
import { useState } from 'react';

function App() {
  const [mycontacts, setMyContacts] = useState<Contact[]>(contacts);

  function handleDelete(id: number): void {
    const contactsAfterDelete = mycontacts.filter(c => c.id !== id);
    setMyContacts(contactsAfterDelete);
  }
  function handleAction(formData:FormData):void{
    //console.log("akcja");
    //console.log(formData);
    const firstname = formData.get("firstname")?.toString()??"";
    const lastname = formData.get("lastname")?.toString()??"";
    const phone = formData.get("phone")?.toString()??"";
    const newContact:Contact = {
      id:getLastId(mycontacts),
      firstname,
      lastname,
      phone
    }
    setMyContacts([...mycontacts,newContact]);    
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
                    <button className='btn btn-outline-secondary'>Edytuj</button>
                  </td>
                </tr>
              )
              )}
            </tbody>
          </table>
        </section>
        <section><h5 className='mb-2'>Dodanie nowego kontaku</h5>
        <form className='mt-4' action={handleAction}>
          <div className="mt-2">
            <label htmlFor="firstname" 
                >Imię</label>
            <input type="text" name="firstname" id="firstname"
             className="form-control" />
          </div>
           <div className="mt-2">
            <label htmlFor="lastname" 
               >Nazwisko</label>
            <input type="text" name="lastname" id="lastname"
             className="form-control" />
          </div>
           <div className="mt-2">
            <label htmlFor="phone" 
               >Telefon</label>
            <input type="text"  id="phone" name='phone'
             className="form-control" />
          </div>
          <div className="mt-2">
            <button type='submit' className="btn btn-outline-primary w-100">Dodaj kontakt</button>
          </div>
        </form>
        </section>
      </main>
      <footer>&copy; 2026 Alojzy Gąbka</footer>
    </>
  )
}

export default App
