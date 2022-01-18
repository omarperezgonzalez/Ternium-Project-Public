const boton = document.getElementById("editarUsuario");
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
    alert(sessionStorage.ID) ;
    UserWeb.value = datos.resultado.UserWeb ;
    UserGit.value = datos.resultado.UserGit ;
    UserTw.value = datos.resultado.UserTw ;
    UserIg.value = datos.resultado.UserIg ;
    UserFb.value = datos.resultado.UserFb ;

    Name.value = datos.resultado.Name ;
    Email.value = datos.resultado.Email ;
    Age.value = datos.resultado.Age ;
    PhoneNum.value = datos.resultado.PhoneNum ;
    JoinDate.value = datos.resultado.JoinDate ;
};

boton.addEventListener("click", async () => { 
 UserWeb = document.getElementById("UserWeb");
 UserGit = document.getElementById("UserGit");
 UserTw = document.getElementById("UserTw");
 UserIg = document.getElementById("UserIg");
 UserFb = document.getElementById("UserFb");
 Name = document.getElementById("Nombre");
 Age = document.getElementById("Edad");
 PhoneNum = document.getElementById("Celular");
 JoinDate = document.getElementById("Antiguedad");
    const data = {
        id: sessionStorage.ID ,
        UserWeb : UserWeb.value,
        UserGit : UserGit.value,
        UserTw : UserTw.value,
    UserIg : UserIg.value,
    UserFb : UserFb.value,
    Name: Name.value,
    Age : Age.value ,
    PhoneNum : PhoneNum.value,
    JoinDate : JoinDate.value};

    const opciones = {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
      };
    
        const respuesta = await fetch("/updateUser", opciones) ;
        const datos = await respuesta.json();
        console.log(datos);

        if (datos.rowsAffected.length == 1) {
            alert("Usuario Actualizado...");
            window.location = "PerfilR.html";
          } else {
            alert("Hubo un error...");
          }

});