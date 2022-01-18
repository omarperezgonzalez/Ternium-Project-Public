let nombre = document.getElementById("1");
let posicion = document.getElementById("2");
let tiempo = document.getElementById("3");
let score = document.getElementById("4");

window.onload = async function load() {
    const data = {
    lugar: 0 };
     const opciones = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
      };
    const respuesta = await fetch("/Ranking", opciones) ;
    const datos = await respuesta.json();
    // alert(datos.resultado[0].Position);
    nombre.textContent = datos.resultado[0].Name;
    posicion.textContent = datos.resultado[0].Position;
    tiempo.textContent = datos.resultado[0].PlayedTime;
    score.textContent = datos.resultado[0].OverallScore;

     nombre = document.getElementById("5");
     posicion = document.getElementById("6");
     tiempo = document.getElementById("7");
     score = document.getElementById("8");

    nombre.textContent = datos.resultado[1].Name;
    posicion.textContent = datos.resultado[1].Position;
    tiempo.textContent = datos.resultado[1].PlayedTime;
    score.textContent = datos.resultado[1].OverallScore;
    

    nombre = document.getElementById("9");
     posicion = document.getElementById("10");
     tiempo = document.getElementById("11");
     score = document.getElementById("12");

    nombre.textContent = datos.resultado[2].Name;
    posicion.textContent = datos.resultado[2].Position;
    tiempo.textContent = datos.resultado[2].PlayedTime;
    score.textContent = datos.resultado[2].OverallScore;

    nombre = document.getElementById("13");
     posicion = document.getElementById("14");
     tiempo = document.getElementById("15");
     score = document.getElementById("16");

    nombre.textContent = datos.resultado[3].Name;
    posicion.textContent = datos.resultado[3].Position;
    tiempo.textContent = datos.resultado[3].PlayedTime;
    score.textContent = datos.resultado[3].OverallScore;

    nombre = document.getElementById("17");
     posicion = document.getElementById("18");
     tiempo = document.getElementById("19");
     score = document.getElementById("20");

    nombre.textContent = datos.resultado[4].Name;
    posicion.textContent = datos.resultado[4].Position;
    tiempo.textContent = datos.resultado[4].PlayedTime;
    score.textContent = datos.resultado[4].OverallScore;

    nombre = document.getElementById("21");
     posicion = document.getElementById("22");
     tiempo = document.getElementById("23");
     score = document.getElementById("24");

    nombre.textContent = datos.resultado[5].Name;
    posicion.textContent = datos.resultado[5].Position;
    tiempo.textContent = datos.resultado[5].PlayedTime;
    score.textContent = datos.resultado[5].OverallScore;

    nombre = document.getElementById("25");
     posicion = document.getElementById("26");
     tiempo = document.getElementById("27");
     score = document.getElementById("28");

    nombre.textContent = datos.resultado[6].Name;
    posicion.textContent = datos.resultado[6].Position;
    tiempo.textContent = datos.resultado[6].PlayedTime;
    score.textContent = datos.resultado[6].OverallScore;

    nombre = document.getElementById("29");
     posicion = document.getElementById("30");
     tiempo = document.getElementById("31");
     score = document.getElementById("32");

    nombre.textContent = datos.resultado[6].Name;
    posicion.textContent = datos.resultado[6].Position;
    tiempo.textContent = datos.resultado[6].PlayedTime;
    score.textContent = datos.resultado[6].OverallScore;

    nombre = document.getElementById("33");
     posicion = document.getElementById("34");
     tiempo = document.getElementById("35");
     score = document.getElementById("36");

    nombre.textContent = datos.resultado[7].Name;
    posicion.textContent = datos.resultado[7].Position;
    tiempo.textContent = datos.resultado[7].PlayedTime;
    score.textContent = datos.resultado[7].OverallScore;
};
