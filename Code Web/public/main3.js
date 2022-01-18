const boton = document.getElementById("boton");
const userType = document.getElementById("inputType");
  const Names = document.getElementById("inputName");
  const userName = document.getElementById("inputEmail");
  const pass = document.getElementById("inputPassword");
boton.addEventListener("click", async () => {
  // alert(userName.value + " " + pass.value);
  sessionStorage.online = userName.value ;
  // Enviar datos al servidor mediante un POST
  const data = {
    type: parseInt(userType.value), 
    name: Names.value,  
    user: userName.value, 
    pass: pass.value };
  const opciones = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  };

    const respuesta = await fetch("/newUser", opciones) ;
    const datos = await respuesta.json();
    if (datos.rowsAffected.length == 1) {
      alert("Usuario Registrado...");
      window.location = "./PerfilR.html";
    } else {
      storage.clear();
      alert("Hubo un error...");
    }

  console.log(datos);
});