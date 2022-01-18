mergeInto(LibraryManager.library,{
    IDAsk: function(){
        alert(sessionStorage.ID);
        window.alert("ID: "+sessionStorage.ID);
        unityInstance.SendMessage('IDContainer','IDFolder',sessionStorage.ID);
    }
});