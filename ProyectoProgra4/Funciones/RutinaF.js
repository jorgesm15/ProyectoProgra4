let toggleCheck = false;

$(document).ready(function () {
    obtenerRutina();
});

function obtenerRutina() {


    var selectedValue = document.getElementById("selectedRutina").value;

    if (selectedValue == 1) {
        var image = new Image();
        image.onload = function () {
            document.getElementById('imgRutina').setAttribute('src', this.src);
        };
        image.src = '/img/rutina-deportista.jpg';
    }
    if (selectedValue == 2) { 
        var image = new Image();
        image.onload = function () {
            document.getElementById('imgRutina').setAttribute('src', this.src);
        };
        image.src = '/img/rutina-aficionado.jpg';

    } else if (selectedValue == 3) { 
        var image = new Image();
        image.onload = function () {
            document.getElementById('imgRutina').setAttribute('src', this.src);
        };
        image.src = '/img/rutina-senior.jpg';

    } else if (selectedValue == 4) {
        var image = new Image();
        image.onload = function () {
            document.getElementById('imgRutina').setAttribute('src', this.src);
        };
        image.src = '/img/rutina-ejecutivo.jpg';

    } else if (selectedValue == 5) { 
        var image = new Image();
        image.onload = function () {
            document.getElementById('imgRutina').setAttribute('src', this.src);
        };
        image.src = '/img/rutina-recuperacion.jpg';
    }
}