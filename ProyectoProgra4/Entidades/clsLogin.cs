using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoProgra4.Entidades
{
    public class clsLogin
    {

        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string correo { get; set; }

        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string contrasenia { get; set; }

        //[Required(ErrorMessage = "Este campo no puede ser vacío.")]
        //public string rol { get; set; }

    }
}