import { useState } from "react";
import { images } from "./data";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle";
// import heroImg from './assets/hero.png'
// import reactLogo from './assets/react.svg'
// import viteLogo from './assets/vite.svg'
import "./App.css";

function App() {
  const [imagesList, setImagesList] = useState(images);
  const [flowers, setFlowers] = useState(true);
  const [animals, setAnimals] = useState(true);
  const [cars, setCars] = useState(true);
  console.log(imagesList);
  function handleClick(id: number): void {
    const elem = imagesList.filter((elem) => elem.id === id);
    elem[0].downloads++;
    setImagesList([...imagesList]);
  }

  return (
    <>
      <h1>Kategorie zdjęć</h1>
      <div className="d-flex gap-4">
        <div className="form-check form-switch">
          <input
            onChange={() => setFlowers(!flowers)}
            checked={flowers}
            className="form-check-input"
            type="checkbox"
            id="ctrId"
          />
          <label className="form-check-label" htmlFor="ctrId">
            Kwiaty
          </label>
        </div>
        <div className="form-check form-switch">
          <input
            onChange={() => setAnimals(!animals)}
            checked={animals}
            className="form-check-input"
            type="checkbox"
            id=" ctrId2"
          />
          <label className="form-check-label" htmlFor=" ctrId2">
            Zwierzęta
          </label>
        </div>
        <div className="form-check form-switch">
          <input
            onChange={() => setCars(!cars)}
            checked={cars}
            className="form-check-input"
            type="checkbox"
            id=" ctrId2"
          />
          <label className="form-check-label" htmlFor=" ctrId2">
            Samochody
          </label>
        </div>
      </div>
      <section className="d-flex gap-3 flex-wrap">
        {imagesList.map((elem) => (
          <div key={elem.id}>
            <img
              style={{ margin: "5px", borderRadius: "5px" }}
              src={`assets/${elem.filename}`}
              alt=""
            />
            <h4>Pobrań: {elem.downloads}</h4>
            <button
              onClick={() => handleClick(elem.id)}
              className="btn btn-success"
            >
              Pobierz
            </button>
          </div>
        ))}
      </section>
    </>
  );
}
export default App;
