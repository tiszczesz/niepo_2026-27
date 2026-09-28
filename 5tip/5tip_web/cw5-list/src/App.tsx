import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { contacts, type Contact } from './data/contacts';
import { useState } from 'react';

function App() {
  const [mycontacts, setMyContacts] = useState<Contact[]>(contacts);

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
            <tbody></tbody>
          </table>
        </section>
        <section><h5>Dodanie nowego kontaku</h5></section>
      </main>
      <footer>&copy; 2026</footer>
    </>
  )
}

export default App
