using System;

namespace ProyectoProgra4.Entidades
{
    public class clsReserva
    {
        public int reservaID { get; set; }
        public int claseID { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dia { get; set; }




        //public String diaFormato { get { return String.Format("{0:yyyy/MM/dd}", dia); } }
        public TimeSpan hora { get; set; }
        public bool equipo { get; set; }
        public string clienteID { get; set; }



    }


}