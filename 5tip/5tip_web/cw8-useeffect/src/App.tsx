import "./App.css";
import Timer from "./components/Timer";

function App() {
  console.log("renderowanie App");
  return (
    <>
      <h1>Czas jest ważny</h1>
      <Timer />
    </>
  );
}

export default App;
