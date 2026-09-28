import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { contacts, type Contact } from './data/contacts';
import { useState } from 'react';

function App() {
  const [mycontacts, setMyContacts] = useState<Contact[]>(contacts);

  function handleDelete(id: number): void {
    const contactsAfterDelete = mycontacts.filter(c => c.id !== id);
    setMyContacts(contactsAfterDelete);
  }

  return (
    <>
      <header><h1>Lista kontaktów</h1></header>
      <main className='d-flex gap-2'>
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
                <tr>
                  <td>{contact.firstname}</td>
                  <td>{contact.lastname}</td>
                  <td>{contact.phone}</td>
                  <td>
                    <button
                      className='btn btn-danger'
                      onClick={() => handleDelete(contact.id)}
                    >Usuń</button>
                    &nbsp;
                    <button className='btn btn-secondary'>Edytuj</button>
                  </td>
                </tr>
              )
              )}
            </tbody>
          </table>
        </section>
        <section><h5>Dodanie nowego kontaku</h5></section>
      </main>
      <footer>&copy; 2026</footer>
    </>
  )
}

export default App
