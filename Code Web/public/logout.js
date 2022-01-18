const boton = document.getElementById("logout");
boton.addEventListener("click", async () => {
    const data = {
        user: sessionStorage.online };
        const opciones = {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    };
    const respuesta = await fetch("/LogOut", opciones) ;
    const datos = await respuesta.json();

    storage.clear();
    if (datos.rowsAffected.length == 1) {
        alert("Usuario Actualizado...");
        window.location = "index.html";
      } else {
        alert("Hubo un error...");
      }
});