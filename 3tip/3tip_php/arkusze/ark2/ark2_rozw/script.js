function generImages() {
  let html = "";
  for (let j = 1; j <= 3; j++) {
    for (let i = 1; i <= 3; i++) {
      html += `<img src='img/${i}.jpg' alt='wycieczki'>`;
    }
  }
  document.querySelector("#column-two").innerHTML = html;
}
const images = [
  { src: "1.jpg", place: "Barcelona" },
  { src: "2.jpg", place: "Rzym" },
  { src: "3.jpg", place: "Londyn" },
];
let currentIndex = 0;
generImages();
const btnUczestnik = document.querySelector("#uczestnik");
btnUczestnik.addEventListener("click", (event) => {
  event.target.style.backgroundColor = "skyblue";
  document.querySelector("#rezerwacja").style.backgroundColor = "dodgerblue";
  const inputsFirst = document.querySelectorAll("#first input");
  const inputsSecond = document.querySelectorAll("#second input");

  inputsFirst.forEach((elem) => {
    elem.disabled = true;
  });
  inputsSecond.forEach((elem) => {
    elem.disabled = false;
  });
});
btnUczestnik.style.backgroundColor = "dodgerblue";
document.querySelector("#up").addEventListener("click", () => {
  currentIndex = currentIndex < images.length - 1 ? currentIndex + 1 : 0;
  document.querySelector("#img").src = `img/${images[currentIndex].src}`;
  document.querySelector("#place").innerHTML = images[currentIndex].place;
});
document.querySelector("#down").addEventListener("click", () => {
  currentIndex = currentIndex < 0 ? images.length - 1 : currentIndex - 1;
  document.querySelector("#img").src = `img/${images[currentIndex].src}`;
  document.querySelector("#place").innerHTML = images[currentIndex].place;
});
