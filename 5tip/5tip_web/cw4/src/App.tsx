import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import './App.css'
import ShowComp from './components/ShowComp';
import ShowCompAlt from './components/ShowCompAlt';

function App() {

  return (
    <>
      <header></header>
      <main>
        <ShowComp />
        <hr />
        <ShowCompAlt />
      </main>
      <footer></footer>
    </>
  )
}

export default App
