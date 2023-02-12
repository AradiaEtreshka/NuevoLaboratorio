const email = document.getElementById('typeEmailX');
const password = document.getElementById('typePasswordX');
const criterio = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;



function validar() {

    if (criterio.test(email.value)) {
        if (String(password.value).length > 5 && password != '') {
            alert("Bienvenido");
            return true;
        }
        else {
            alert("Contraseña incorrecta");
            return false;
        }
    }

    else {
        alert("Correo incorrecto");
        return false;
    }
}