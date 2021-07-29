function ActualizarDatos(clienteId) {
    $.ajax({
        type: 'Post',
        url: '/Clientes/ActualizarDatos',
        data: {
            clienteId: clienteId
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            window.scroll(0, 0);
            $("#actualizarContainer").removeClass('hidden');
            $('#btnActualizarCambios').show();
            document.getElementById("cedulaPersona").value = data.ID_Cliente;
            document.getElementById("txtNombre").value = data.Nombre;
            document.getElementById("txtPrimerApellido").value = data.PrimerApellido;
            document.getElementById("txtSegundoApellido").value = data.SegundoApellido;
            document.getElementById("txtCorreo").value = data.Correo;
            document.getElementById("txtEdad").value = data.Edad;
            document.getElementById("txtTlf").value = data.Telefono;
            document.getElementById("txtTlfEmergencia").value = data.TelefonoEmergencia;
            document.getElementById("txtPeso").value = data.Peso;
            document.getElementById("txtEstatura").value = data.Estatura;
            document.getElementById("txtCondiciones").value = data.CondicionesMedicas;

            //debugger;
            //document.getElementById("reservaTXT").value = data.reservaID;
        },
        error: function (data) {
            alert("Se presentó un error")
        }

    });

}


function EliminarCliente(clienteId) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar al cliente?',
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
                url: '/Clientes/EliminarCliente',
                data: {
                    clienteId: clienteId
                },
                cache: false,
                dataType: 'json',
                success: function (data) {
                    swal.fire({
                        instructorId: clienteId,
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