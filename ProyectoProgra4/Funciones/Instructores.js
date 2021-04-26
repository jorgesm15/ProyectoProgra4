function ActualizarDatos(instructorId) {
    $.ajax({
        type: 'Post',
        url: '/AdministrarInstructor/ActualizarDatosInstructor',
        data: {
            instructorId: instructorId
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            window.scroll(0, 0);
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


function EliminarInstructor(instructorId) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar al instructor?',
        text: "Este cambio no podrá ser revertido.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'Post',
                url: '/AdministrarInstructor/EliminarInstructor',
                data: {
                    instructorId: instructorId
                },
                cache: false,
                dataType: 'json',
                success: function (data) {
                    swal.fire({
                        instructorId: instructorId,
                        title: 'Eliminado',
                        text: 'El cliente se ha eliminado correctamente',
                        icon: 'success'
                    });
                },
            })
            setTimeout(function () {
                location.reload();
            }, 1000)
        }
    });
}

function EsconderDiv() {
    $("#actualizarContainer").addClass('hidden');
    event.preventDefault();
}