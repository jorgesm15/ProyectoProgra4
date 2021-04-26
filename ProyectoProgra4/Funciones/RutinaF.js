
function ObtenerRutina(ID_Ejercicio) {
    $.ajax({
        type: 'Post',
        url: '/Rutina/ActualizarDatos',
        data: {
            ID_Ejercicio: ID_Ejercicio
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            $("#actualizarContainer").removeClass('hidden');
            $('#btnActualizarCambios').show();
            document.getElementById("txtIdEjercicio").value = data.ID_Ejercicio;
            document.getElementById("txtNomEjercicio").value = data.NomEjercicio;
            document.getElementById("txtDuracion").value = data.Duracion;
            document.getElementById("txtSeries").value = data.Series;
            document.getElementById("txtRepeticion").value = data.Repeticion;
            document.getElementById("txtDescanso").value = data.Descanso;
        },
        error: function (data) {
            alert("MAL")
        }

    });

}

function EsconderDiv() {
    $("#actualizarContainer").addClass('hidden');
    event.preventDefault();
}