//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoProgra4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        public int reservaID { get; set; }
        public int claseID { get; set; }
        public System.DateTime dia { get; set; }
        public System.TimeSpan hora { get; set; }
        public bool equipo { get; set; }
        public string ID_Cliente { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Disciplinas Disciplinas { get; set; }

        public string nombreDis { get; set; }
    }
}
