 let toggleCheck = false;

$(document).ready(function () {
    obtenerValor();
    $('#btnActualizarCambios').hide();
    $("#dia").on("keypress keyup blur", function (event) {
        VerificacionNumeros(event);
    });
    $("#hora").on("keypress keyup blur", function (event) {
        VerificacionNumeros(event);
    });

    
});

$('#selectedDis').on('change', function () {
    $('#dia').val(" ");
    $('#hora').val(" ");

});

function obtenerValor()  {
    
    var selectedValue = document.getElementById("selectedDis").value;
    document.getElementById("dia").value = " ";
    document.getElementById("hora").value = " ";

    if (selectedValue == 2) { //Condiciones por si se selecciona Yoga
  
        $('#custom_format_calendar').calendar({  //seleccion dia
            disabledDaysOfWeek: [0, 2, 3, 4, 5, 6],
            monthFirst: false,
            type: 'date',
            formatter: {
                date: function (date, settings) {
                    if (!date) return '';
                    var day = date.getDate();
                    var month = date.getMonth() + 1;
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;

                }
            },
            

        })

        var minDate = new Date();           //seleccion hora
        var maxDate = new Date();
        minDate.setHours(17, 0);
        maxDate.setHours(17, 0);

        $('#time_calendar')
            .calendar({
                type: 'time',
                disableMinute: true,
                minDate: minDate,
                maxDate: maxDate,
                
            })

        

    } else if (selectedValue == 3) { //Condiciones por si se selecciona Pilates
        $('#custom_format_calendar').calendar({
            disabledDaysOfWeek: [0, 1, 3, 4, 5, 6],
            monthFirst: false,
            type: 'date',
            formatter: {
                date: function (date, settings) {
                    if (!date) return '';
                    var day = date.getDate();
                    var month = date.getMonth() + 1;
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },
            
        })

        var minDate = new Date();
        var maxDate = new Date();
        minDate.setHours(18, 0);
        maxDate.setHours(18, 0);

        $('#time_calendar')
            .calendar({
                type: 'time',
                disableMinute: true,
                minDate: minDate,
                maxDate: maxDate,

            })

      

    } else if (selectedValue == 4) { //Condiciones por si se selecciona Fitness
        $('#custom_format_calendar').calendar({
            disabledDaysOfWeek: [0, 1, 2, 4, 5, 6],
            monthFirst: false,
            type: 'date',
            formatter: {
                date: function (date, settings) {
                    if (!date) return '';
                    var day = date.getDate();
                    var month = date.getMonth() + 1;
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },
            
        })

        var minDate = new Date();
        var maxDate = new Date();
        minDate.setHours(19, 0);
        maxDate.setHours(19, 0);

        $('#time_calendar')
            .calendar({
                type: 'time',
                disableMinute: true,
                minDate: minDate,
                maxDate: maxDate,

            })


    } else if (selectedValue == 5) { //Condiciones por si se selecciona Funcional
        $('#custom_format_calendar').calendar({
           disabledDaysOfWeek: [0, 1, 2, 3, 5, 6],
           monthFirst: false,
           type: 'date',
           formatter: {
                date: function (date, settings) {
                    if (!date) return '';
                    var day = date.getDate();
                    var month = date.getMonth() + 1;
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },
           
        })

        var minDate = new Date();
        var maxDate = new Date();
        minDate.setHours(17, 0);
        maxDate.setHours(17, 0);

        $('#time_calendar')
           .calendar({
                type: 'time',
                disableMinute: true,
                minDate: minDate,
                maxDate: maxDate,

            })
    }
}

function obtenerHora() {
    
    document.getElementById("hora").value = document.getElementById("hora").value.split(" ")[0];  

    return false;

}


function toggle() {

    $('.ui.checkbox')
        .checkbox()
        ;

    toggleCheck = !toggleCheck;

    console.log('Toggled bool is',
        toggleCheck);
}

function ActualizarDatos(reservaID){

    $.ajax({
        type: 'Post',
        url: '/Reservar/ActualizarDatos',
        data: {
            reservaID: reservaID
        },
        cache: false,
        dataType: 'json',
        success: function (data) {

            $('#btnReservar').hide();
            $('#btnActualizarCambios').show();
            
            document.getElementById("selectedDis").value = data.claseID;
            obtenerValor();
            document.getElementById("dia").value = data.dia;
            document.getElementById("hora").value = data.hora;
            
            document.getElementById("reservaTXT").value = data.reservaID;
        },
        error: function (data) {
            aler("MAL")
        }
        
    });
   
}


function VerificacionNumeros(event) {

    if (event.which < 00 && event.which > 175)
        return true;
    else
        event.preventDefault();

};

function ValidarFecha() {
    let fechaInput = document.getElementById("dia").value.split("/");
    var valorSeleccionado = new Date(fechaInput[1] + "/" + fechaInput[0] + "/" + fechaInput[2]);
    let hoy = new Date();
    //let  fechaActual = hoy.getDate() + '/' + (hoy.getMonth() + 1) + '/' + hoy.getFullYear();
    //valorSeleccionado = new Date();
    
    //hoy = new Date(fechaActual);


    if (valorSeleccionado > hoy) {

        return true;
        
    } else {
        alert("menor");
        
            //$('#dia').val(" ");
            //$('#hora').val(" ");
        document.getElementById("dia").value = '';
        document.getElementById("hora").value = '';
        
        return false;

    }
       
    
    
}