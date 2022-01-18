const boton = document.getElementById("boton");
const userName = document.getElementById("inputEmail");
const pass = document.getElementById("inputPassword");

boton.addEventListener("click", async () => {
  //alert(userName.value + " " + pass.value);
  // Enviar datos al servidor mediante un POST
  sessionStorage.online = userName.value ;
  const data = { user: userName.value, pass: pass.value };
  const opciones = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  };

    const respuesta = await fetch("/LoginAdmin", opciones) ;
    const datos = await respuesta.json();
    console.log(datos);
  if (datos.login) {
    window.location = "./Admin.html";
    //alert(datos.login);
  } else {
    storage.clear();
    alert("Datos incorrectos");
    userName.value = "";
    pass.value = "";
  }
});