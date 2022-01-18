let UserWeb = document.getElementById("UserWeb");
let UserGit = document.getElementById("UserGit");
let UserTw = document.getElementById("UserTw");
let UserIg = document.getElementById("UserIg");
let UserFb = document.getElementById("UserFb");
let Name = document.getElementById("Nombre");
let Email = document.getElementById("Correo");
let Age = document.getElementById("Edad");
let PhoneNum = document.getElementById("Celular");
let JoinDate = document.getElementById("Antiguedad");

window.onload = async function load() {
    const data = {
        user: sessionStorage.online };
         const opciones = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    };
    const respuesta = await fetch("/Perfil", opciones) ;
    const datos = await respuesta.json();
    console.log(datos);
    sessionStorage.ID = datos.resultado.UserID ;
    //alert(sessionStorage.ID) ;
    UserWeb.textContent = datos.resultado.UserWeb ;
    UserGit.textContent = datos.resultado.UserGit ;
    UserTw.textContent = datos.resultado.UserTw ;
    UserIg.textContent = datos.resultado.UserIg ;
    UserFb.textContent = datos.resultado.UserFb ;

    Name.textContent = datos.resultado.Name ;
    Email.textContent = datos.resultado.Email ;
    Age.textContent = datos.resultado.Age ;
    PhoneNum.textContent = datos.resultado.PhoneNum ;
    JoinDate.textContent = datos.resultado.JoinDate ;
};