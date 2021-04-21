//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoProgra4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.Reserva = new HashSet<Reserva>();
        }
    
        public string ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoEmergencia { get; set; }
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }
        public string CondicionesMedicas { get; set; }
        public int ID_Motivo { get; set; }
        public string Rol { get; set; }
        public int ID_Sexo { get; set; }
        public int ID_TipoSangre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual Motivo Motivo { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual TipoSangre TipoSangre { get; set; }
    }
}
