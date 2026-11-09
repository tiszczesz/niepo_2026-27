import { useEffect,useState } from "react";
function Timer() {
  console.log("renderowanie... Timer");
  const [time,setTime] = useState(new Date())
  //useEffect wykorzystywany do wykonywania efektów ubocznych w komponentach funkcyjnych.
  //  W tym przypadku używamy go do ustawienia interwału, który 
  // aktualizuje stan czasu co sekundę. Funkcja zwrotna w useEffect działa jako "cleanup",
  //  która jest wywoływana, gdy komponent jest odmontowywany lub przed kolejnym wywołaniem 
  // efektu, aby uniknąć wycieków pamięci.
  // uzycie do pobierania z api
  useEffect(()=>{
    //co sekunde generownie czasu
    const timerId = setInterval(()=>{
        setTime(new Date());
    },1000);
    return ()=>{
        console.log("czyszczenie timeInterval o id: "+timerId)
        clearInterval(timerId)};//czyszczenie timeInterval po użyciu
  },[]);
  return <div>
    <h3>Aktualny czas: {time.toLocaleTimeString()}</h3>
  </div>;
}

export default Timer;
