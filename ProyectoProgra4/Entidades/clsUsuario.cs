using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra4.Entidades
{
    public class clsUsuario
    {
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string primerApellido { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string segundoApellido { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string correo { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        [Range(0, 100, ErrorMessage = "Ingrese un numero entre 1-100")]
        public int edad { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string contrasenia { get; set; }
        //[Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string direccion { get; set; }


        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "El número de teléfono debe ser de 8 dígitos.")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }


        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "El número de teléfono debe ser de 8 dígitos.")]
        [DataType(DataType.PhoneNumber)]
        public string telefonoEmergencia { get; set; }

        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public decimal peso { get; set; }
        
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public decimal estatura { get; set; }
        
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string condicionesMedicas { get; set; }
        
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]


        public int tipoSangre { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]

        public int motivo { get; set; }

        public string rol { get; set; }

        public int ID_Sexo { get; set; }

    }
}