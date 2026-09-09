import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
const colors = ['red', 'blue', 'green', 'yellow', 'orange', 'purple', 'pink',
   'brown', 'gray', 'black','white', 'cyan', 'magenta', 'lime', 'teal', 'indigo', 'violet', 'gold', 'silver', 'bronze'];
const flowers = ['rose', 'tulip', 'daisy', 'sunflower', 'lily', 'orchid', 'daffodil', 'marigold', 'lavender', 'peony'];   
function App() {
 

  return (
    <main className='container'>
      <h2>Zabawa kolorami</h2>
     <section className='row'>
      <section className='col-6 scene'></section>
      <section className='col-6'>
        <p>Wybierz kolor:</p>
        <select>
          {colors.map((elem)=>(
            <option key={elem} value={elem}>{elem}</option>
          ))}
        </select>
      </section>
     </section>
     <section>
      {/* lista numerowana kwiatów */}
     </section>
    </main>
  )
}

export default App
