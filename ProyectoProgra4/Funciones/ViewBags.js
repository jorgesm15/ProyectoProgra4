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
    //document.getElementById("msjError").style.visibility = "hidden";
    if ($("#txtErrorUsuario").val() != "") {
        $("#msjError").removeClass('hidden');
        document.getElementById("contraseniaPersona").value = '';
        //document.getElementById("msjError").style.visibility = "visible";
    }
});

$(document).ready(function () {
    document.getElementById("msjExito").style.visibility = "hidden";
    if ($("#txtSuccessful").val() != "") {
        document.getElementById("msjExito").style.visibility = "visible";
    }
});