using System.ComponentModel.DataAnnotations;
namespace ProyectoProgra4.Entidades
{
    public class clsRutina
    {
        public string nomEjercicio { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public decimal duracion { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public int series { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string repeticion { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        public string descanso { get; set; }

    }


}