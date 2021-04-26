
function ObtenerRutina(ID_Ejercicio) {
    $.ajax({
        type: 'Post',
        url: '/Rutina/ActualizarRutina',
        data: {
            ID_Ejercicio: ID_Ejercicio
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            $("#actualizarContainer").removeClass('hidden');
            $('#btnActualizarCambios').show();
            document.getElementById("txtNomEjercicio").value = data.ID_Instructor;
            document.getElementById("txtDuracion").value = data.Nombre;
            document.getElementById("txtSeries").value = data.PrimerApellido;
            document.getElementById("txtRepeticion").value = data.SegundoApellido;
            document.getElementById("txtDuracion").value = data.Correo;
        },
        error: function (data) {
            aler("MAL")
        }

    });

}