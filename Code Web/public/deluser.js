const boton = document.getElementById("botonBuscar");
const userName = document.getElementById("userInput");
const pass = document.getElementById("pass");

boton.addEventListener("click", async () => { 
    const data = { user: userName.value, pass: pass.value};

    const opciones = {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    };

    const respuesta = await fetch("/delete", opciones);
    const datos = await respuesta.json();
    console.log(datos.rowsAffected.length);
    if (datos.rowsAffected.length == 1) {
    alert("Usuario eliminado...");
    window.location = "delete.html";
    } else {
    alert("Hubo un error...");
    }
});
