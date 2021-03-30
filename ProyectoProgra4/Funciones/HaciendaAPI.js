function ConsultarPersona() {

    var cedula = document.getElementById("cedulaPersona").value;

    $.ajax({
        type: 'Post',
        url: '/Registrar/RegistrarUsuario',
        data: {
            cedula: cedula
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            nombre = data.nombre;
            var separador = [];
            var separador = nombre.split(' ');
            document.getElementById("txtNombre").value = separador[0];
            document.getElementById("txtPrimerApellido").value = separador[2];
            document.getElementById("txtSegundoApellido").value = separador[3];
        },
        error: function (data) {
            Swal.fire({
                icon: 'error',
                title: 'Verifique su cédula',
                text: 'Asegúrese que escribio correctamente la cédula'
            });
            document.getElementById("cedulaPersona").value = '';
        }
    });
    document.getElementById("cedulaPersona").focus();
}

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
    document.getElementById("msjError").style.visibility = "hidden";
    if ($("#txtErrorUsuario").val().trim() != "") {
        document.getElementById("contraseniaPersona").value = '';
        document.getElementById("msjError").style.visibility = "visible";
    }

});