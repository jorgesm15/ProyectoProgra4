 let toggleCheck = false;

$(document).ready(function () {
    obtenerValor();
});

function obtenerValor() {


    var selectedValue = document.getElementById("selectedDis").value;

    if (selectedValue == 1) {
        $('#custom_format_calendar').calendar({
            disabledDaysOfWeek: [0, 1, 2, 3, 4, 5, 6],
            monthFirst: false,
            type: 'date'
            
        })
        $('#time_calendar')
            .calendar({
                type: 'time',
                touchReadonly: true,
                disableMinute: true        
            })
    }
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
            }

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
            }
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
            }
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
           }
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

    

}


function toggle() {

    $('.ui.checkbox')
        .checkbox()
        ;

    toggleCheck = !toggleCheck;

    console.log('Toggled bool is',
        toggleCheck);
}

