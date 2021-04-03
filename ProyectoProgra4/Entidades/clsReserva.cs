using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgra4.Entidades
{
    public class clsReserva
    {
        public int claseID { get; set; }
        public  DateTime dia { get; set; }
        public TimeSpan hora { get; set; }
        public bool equipo { get; set; }
        public string clienteID { get; set; }

    }
}