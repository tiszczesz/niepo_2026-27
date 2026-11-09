import "./App.css";
import Stopper from "./components/Stopper";
import Timer from "./components/Timer";

function App() {
  console.log("renderowanie App");
  return (
    <>
      <h1>Czas jest ważny</h1>
      <Timer />
      <Stopper duration={180} />
      <Stopper duration={60*5} />
    </>
  );
}

export default App;
