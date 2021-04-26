$(document).ready(function () {
    if ($("#txtError").val().trim() != "") {
        Swal.fire({
            icon: 'error',
            title: 'Usuario ya registrado',
            text: 'El usuario ya existe, intente con otro número de cédula o correo electrónico.'
        });

        document.getElementById("cedulaPersona").value = '';
        document.getElementById("txtCorreo").value = '';
        document.getElementById("txtNombre").value = '';
        document.getElementById("txtPrimerApellido").value = '';
        document.getElementById("txtSegundoApellido").value = '';

    }

});

$(document).ready(function () {
    if ($("#txtErrorUsuario").val() != "") {
        $("#msjError").removeClass('hidden');
        document.getElementById("contraseniaPersona").value = '';
    }
});

$(document).ready(function () {
    if ($("#txtSuccessful").val() != "") {
        $("#msjLoginExito").removeClass('hidden');
        setTimeout(function () {
            $("#msjLoginExito").fadeOut(300)
        }, 5000);
    } else {
        $("#msjLoginExito").addClass('hidden');
    }
});

$(document).ready(function () {
    if ($("#txtExito").val() != "") {
        $("#msjExitoInstructor").removeClass('hidden');
        setTimeout(function () {
            $("#msjExitoInstructor").fadeOut(300)
        }, 5000);
        $("#formInstructor").trigger('reset');
    }
});

$(document).ready(function () {
    if ($("#txtErrorReserva").val() != "") {
        $("#msjErrorReserva").removeClass('hidden');
        setTimeout(function () {
            $("#msjErrorReserva").fadeOut(300)
        }, 5000);
        document.getElementById("dia").value = '';
        document.getElementById("hora").value = '';
    }
});
