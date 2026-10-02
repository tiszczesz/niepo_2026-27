document.querySelector("select").onchange = function (event) {
  const scene = document.querySelector("#scene");
  scene.style.background = event.target.value;
};

