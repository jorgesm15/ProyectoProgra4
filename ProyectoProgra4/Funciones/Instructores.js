function ActualizarDatos(instructorId) {
    $.ajax({
        type: 'Post',
        url: '/AdministrarInstructor/ActualizarDatos',
        data: {
            instructorId: instructorId
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            $("#actualizarContainer").removeClass('hidden');
            $('#btnActualizarCambios').show();
            document.getElementById("cedulaPersona").value = data.ID_Instructor;
            document.getElementById("txtNombre").value = data.Nombre;
            document.getElementById("txtPrimerApellido").value = data.PrimerApellido;
            document.getElementById("txtSegundoApellido").value = data.SegundoApellido;
            document.getElementById("txtCorreo").value = data.Correo;
            document.getElementById("txtEdad").value = data.Edad;
            document.getElementById("txtTlf").value = data.Telefono;
            document.getElementById("txtTlfEmergencia").value = data.TelefonoEmergencia;
            document.getElementById("selectedEspecialidad").value = data.Especialidad;
            document.getElementById("txtCondiciones").value = data.CondicionesMedicas;

            //debugger;
            //document.getElementById("reservaTXT").value = data.reservaID;
        },
        error: function (data) {
            aler("MAL")
        }

    });

}

function EsconderDiv() {
    $("#actualizarContainer").addClass('hidden');
    event.preventDefault(); 
}