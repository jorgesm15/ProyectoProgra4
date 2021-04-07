using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoProgra4.Entidades
{
    public class clsUsuario
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correo { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        [Range(0, 100, ErrorMessage = "Ingrese un numero entre 1-100")]
        public int edad { get; set; }
        public string contrasenia { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string telefonoEmergencia { get; set; }
        public decimal peso { get; set; }
        public decimal estatura { get; set; }
        public string condicionesMedicas { get; set; }
        public string tipoSangre { get; set; }
        public int motivo{ get; set; }



    }
}