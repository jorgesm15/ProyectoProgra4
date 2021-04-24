$(document).ready(function () {
    if ($("#txtError").val().trim() != "") {
        Swal.fire({
            icon: 'error',
            title: 'Usuario ya registrado',
            text: 'Intente con otra cédula'
        });

        document.getElementById("cedulaPersona").value = '';
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
        $("#msjExito").removeClass('hidden');
        setTimeout(function () {
            $("#msjExito").fadeOut(300)
        }, 5000);
    }
});

$(document).ready(function () {
    if ($("#txtExito").val() != "") {
        $("#msjExito").removeClass('hidden');
        setTimeout(function () {
            $("#msjExito").fadeOut(300)
        }, 5000);
    }
});

$(document).ready(function () {
    if ($("#txtErrorReserva").val() != "") {
        $("#msjErrorReserva").removeClass('hidden');
        document.getElementById("dia").value = '';
        document.getElementById("hora").value = '';
    }
});
