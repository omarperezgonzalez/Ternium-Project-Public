const boton = document.getElementById("LinkalVideo");
const link = document.getElementById("Link");
//const tema = document.getElementById("Tema");

boton.addEventListener("click", async () => { 
    alert("enviando...");
    const data = { link: link.value, id: sessionStorage.ID };
    const opciones = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
    };
    const respuesta = await fetch("/linkV", opciones) ;
    const datos = await respuesta.json();
    console.log(datos);
    if (datos.rowsAffected.length == 1) {
        window.location = "PerfilR.html";
      } else {
        alert("Hubo un error...");
      }
});