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