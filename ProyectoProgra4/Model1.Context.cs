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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoEntities : DbContext
    {
        public ProyectoEntities()
            : base("name=ProyectoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Disciplinas> Disciplinas { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Motivo> Motivo { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Rutinas> Rutinas { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoSangre> TipoSangre { get; set; }
        public virtual DbSet<Errores> Errores { get; set; }
    
        public virtual int ActualizarInstructor(string pIdInstructor, string pNombre, string pPrimerApellido, string pSegundoApellido, string pCorreo, Nullable<int> pEdad, string pDireccion, string pTelefono, string pTelefonoEmergencia, string pCondicionesMedicas, Nullable<int> pIdEspecialidad, Nullable<int> pIdAdministrador)
        {
            var pIdInstructorParameter = pIdInstructor != null ?
                new ObjectParameter("pIdInstructor", pIdInstructor) :
                new ObjectParameter("pIdInstructor", typeof(string));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPrimerApellidoParameter = pPrimerApellido != null ?
                new ObjectParameter("pPrimerApellido", pPrimerApellido) :
                new ObjectParameter("pPrimerApellido", typeof(string));
    
            var pSegundoApellidoParameter = pSegundoApellido != null ?
                new ObjectParameter("pSegundoApellido", pSegundoApellido) :
                new ObjectParameter("pSegundoApellido", typeof(string));
    
            var pCorreoParameter = pCorreo != null ?
                new ObjectParameter("pCorreo", pCorreo) :
                new ObjectParameter("pCorreo", typeof(string));
    
            var pEdadParameter = pEdad.HasValue ?
                new ObjectParameter("pEdad", pEdad) :
                new ObjectParameter("pEdad", typeof(int));
    
            var pDireccionParameter = pDireccion != null ?
                new ObjectParameter("pDireccion", pDireccion) :
                new ObjectParameter("pDireccion", typeof(string));
    
            var pTelefonoParameter = pTelefono != null ?
                new ObjectParameter("pTelefono", pTelefono) :
                new ObjectParameter("pTelefono", typeof(string));
    
            var pTelefonoEmergenciaParameter = pTelefonoEmergencia != null ?
                new ObjectParameter("pTelefonoEmergencia", pTelefonoEmergencia) :
                new ObjectParameter("pTelefonoEmergencia", typeof(string));
    
            var pCondicionesMedicasParameter = pCondicionesMedicas != null ?
                new ObjectParameter("pCondicionesMedicas", pCondicionesMedicas) :
                new ObjectParameter("pCondicionesMedicas", typeof(string));
    
            var pIdEspecialidadParameter = pIdEspecialidad.HasValue ?
                new ObjectParameter("pIdEspecialidad", pIdEspecialidad) :
                new ObjectParameter("pIdEspecialidad", typeof(int));
    
            var pIdAdministradorParameter = pIdAdministrador.HasValue ?
                new ObjectParameter("pIdAdministrador", pIdAdministrador) :
                new ObjectParameter("pIdAdministrador", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarInstructor", pIdInstructorParameter, pNombreParameter, pPrimerApellidoParameter, pSegundoApellidoParameter, pCorreoParameter, pEdadParameter, pDireccionParameter, pTelefonoParameter, pTelefonoEmergenciaParameter, pCondicionesMedicasParameter, pIdEspecialidadParameter, pIdAdministradorParameter);
        }
    
        public virtual int ActualizarReserva(Nullable<int> reservaID, Nullable<int> claseID, Nullable<System.DateTime> dia, Nullable<System.TimeSpan> hora, Nullable<bool> equipo, string idCliente)
        {
            var reservaIDParameter = reservaID.HasValue ?
                new ObjectParameter("reservaID", reservaID) :
                new ObjectParameter("reservaID", typeof(int));
    
            var claseIDParameter = claseID.HasValue ?
                new ObjectParameter("claseID", claseID) :
                new ObjectParameter("claseID", typeof(int));
    
            var diaParameter = dia.HasValue ?
                new ObjectParameter("dia", dia) :
                new ObjectParameter("dia", typeof(System.DateTime));
    
            var horaParameter = hora.HasValue ?
                new ObjectParameter("hora", hora) :
                new ObjectParameter("hora", typeof(System.TimeSpan));
    
            var equipoParameter = equipo.HasValue ?
                new ObjectParameter("equipo", equipo) :
                new ObjectParameter("equipo", typeof(bool));
    
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("idCliente", idCliente) :
                new ObjectParameter("idCliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarReserva", reservaIDParameter, claseIDParameter, diaParameter, horaParameter, equipoParameter, idClienteParameter);
        }
    
        public virtual int InsertarClientes(string pIdCliente, string pNombre, string pPrimerApellido, string pSegundoApellido, string pCorreo, Nullable<int> pEdad, string pContraseña, string pDireccion, string pTelefono, string pTelefonoEmergencia, Nullable<decimal> pPeso, Nullable<decimal> pEstatura, string pCondicionesMedicas, Nullable<int> pIdMotivo, string pRol, Nullable<int> pSexo, Nullable<int> pIdTipoSangre)
        {
            var pIdClienteParameter = pIdCliente != null ?
                new ObjectParameter("pIdCliente", pIdCliente) :
                new ObjectParameter("pIdCliente", typeof(string));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPrimerApellidoParameter = pPrimerApellido != null ?
                new ObjectParameter("pPrimerApellido", pPrimerApellido) :
                new ObjectParameter("pPrimerApellido", typeof(string));
    
            var pSegundoApellidoParameter = pSegundoApellido != null ?
                new ObjectParameter("pSegundoApellido", pSegundoApellido) :
                new ObjectParameter("pSegundoApellido", typeof(string));
    
            var pCorreoParameter = pCorreo != null ?
                new ObjectParameter("pCorreo", pCorreo) :
                new ObjectParameter("pCorreo", typeof(string));
    
            var pEdadParameter = pEdad.HasValue ?
                new ObjectParameter("pEdad", pEdad) :
                new ObjectParameter("pEdad", typeof(int));
    
            var pContraseñaParameter = pContraseña != null ?
                new ObjectParameter("pContraseña", pContraseña) :
                new ObjectParameter("pContraseña", typeof(string));
    
            var pDireccionParameter = pDireccion != null ?
                new ObjectParameter("pDireccion", pDireccion) :
                new ObjectParameter("pDireccion", typeof(string));
    
            var pTelefonoParameter = pTelefono != null ?
                new ObjectParameter("pTelefono", pTelefono) :
                new ObjectParameter("pTelefono", typeof(string));
    
            var pTelefonoEmergenciaParameter = pTelefonoEmergencia != null ?
                new ObjectParameter("pTelefonoEmergencia", pTelefonoEmergencia) :
                new ObjectParameter("pTelefonoEmergencia", typeof(string));
    
            var pPesoParameter = pPeso.HasValue ?
                new ObjectParameter("pPeso", pPeso) :
                new ObjectParameter("pPeso", typeof(decimal));
    
            var pEstaturaParameter = pEstatura.HasValue ?
                new ObjectParameter("pEstatura", pEstatura) :
                new ObjectParameter("pEstatura", typeof(decimal));
    
            var pCondicionesMedicasParameter = pCondicionesMedicas != null ?
                new ObjectParameter("pCondicionesMedicas", pCondicionesMedicas) :
                new ObjectParameter("pCondicionesMedicas", typeof(string));
    
            var pIdMotivoParameter = pIdMotivo.HasValue ?
                new ObjectParameter("pIdMotivo", pIdMotivo) :
                new ObjectParameter("pIdMotivo", typeof(int));
    
            var pRolParameter = pRol != null ?
                new ObjectParameter("pRol", pRol) :
                new ObjectParameter("pRol", typeof(string));
    
            var pSexoParameter = pSexo.HasValue ?
                new ObjectParameter("pSexo", pSexo) :
                new ObjectParameter("pSexo", typeof(int));
    
            var pIdTipoSangreParameter = pIdTipoSangre.HasValue ?
                new ObjectParameter("pIdTipoSangre", pIdTipoSangre) :
                new ObjectParameter("pIdTipoSangre", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarClientes", pIdClienteParameter, pNombreParameter, pPrimerApellidoParameter, pSegundoApellidoParameter, pCorreoParameter, pEdadParameter, pContraseñaParameter, pDireccionParameter, pTelefonoParameter, pTelefonoEmergenciaParameter, pPesoParameter, pEstaturaParameter, pCondicionesMedicasParameter, pIdMotivoParameter, pRolParameter, pSexoParameter, pIdTipoSangreParameter);
        }
    
        public virtual int InsertarErrores(string pDescripcion, string pCliente, Nullable<System.DateTime> pDia)
        {
            var pDescripcionParameter = pDescripcion != null ?
                new ObjectParameter("pDescripcion", pDescripcion) :
                new ObjectParameter("pDescripcion", typeof(string));
    
            var pClienteParameter = pCliente != null ?
                new ObjectParameter("pCliente", pCliente) :
                new ObjectParameter("pCliente", typeof(string));
    
            var pDiaParameter = pDia.HasValue ?
                new ObjectParameter("pDia", pDia) :
                new ObjectParameter("pDia", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarErrores", pDescripcionParameter, pClienteParameter, pDiaParameter);
        }
    
        public virtual int InsertarInstructores(string pIdInstructor, string pNombre, string pPrimerApellido, string pSegundoApellido, string pCorreo, Nullable<int> pEdad, string pContraseña, string pDireccion, string pTelefono, string pTelefonoEmergencia, string pCondicionesMedicas, Nullable<int> pIdEspecialidad, Nullable<int> pIdAdministrador, string pRol, Nullable<int> pIdSexo, Nullable<int> pIdTipoSangre)
        {
            var pIdInstructorParameter = pIdInstructor != null ?
                new ObjectParameter("pIdInstructor", pIdInstructor) :
                new ObjectParameter("pIdInstructor", typeof(string));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPrimerApellidoParameter = pPrimerApellido != null ?
                new ObjectParameter("pPrimerApellido", pPrimerApellido) :
                new ObjectParameter("pPrimerApellido", typeof(string));
    
            var pSegundoApellidoParameter = pSegundoApellido != null ?
                new ObjectParameter("pSegundoApellido", pSegundoApellido) :
                new ObjectParameter("pSegundoApellido", typeof(string));
    
            var pCorreoParameter = pCorreo != null ?
                new ObjectParameter("pCorreo", pCorreo) :
                new ObjectParameter("pCorreo", typeof(string));
    
            var pEdadParameter = pEdad.HasValue ?
                new ObjectParameter("pEdad", pEdad) :
                new ObjectParameter("pEdad", typeof(int));
    
            var pContraseñaParameter = pContraseña != null ?
                new ObjectParameter("pContraseña", pContraseña) :
                new ObjectParameter("pContraseña", typeof(string));
    
            var pDireccionParameter = pDireccion != null ?
                new ObjectParameter("pDireccion", pDireccion) :
                new ObjectParameter("pDireccion", typeof(string));
    
            var pTelefonoParameter = pTelefono != null ?
                new ObjectParameter("pTelefono", pTelefono) :
                new ObjectParameter("pTelefono", typeof(string));
    
            var pTelefonoEmergenciaParameter = pTelefonoEmergencia != null ?
                new ObjectParameter("pTelefonoEmergencia", pTelefonoEmergencia) :
                new ObjectParameter("pTelefonoEmergencia", typeof(string));
    
            var pCondicionesMedicasParameter = pCondicionesMedicas != null ?
                new ObjectParameter("pCondicionesMedicas", pCondicionesMedicas) :
                new ObjectParameter("pCondicionesMedicas", typeof(string));
    
            var pIdEspecialidadParameter = pIdEspecialidad.HasValue ?
                new ObjectParameter("pIdEspecialidad", pIdEspecialidad) :
                new ObjectParameter("pIdEspecialidad", typeof(int));
    
            var pIdAdministradorParameter = pIdAdministrador.HasValue ?
                new ObjectParameter("pIdAdministrador", pIdAdministrador) :
                new ObjectParameter("pIdAdministrador", typeof(int));
    
            var pRolParameter = pRol != null ?
                new ObjectParameter("pRol", pRol) :
                new ObjectParameter("pRol", typeof(string));
    
            var pIdSexoParameter = pIdSexo.HasValue ?
                new ObjectParameter("pIdSexo", pIdSexo) :
                new ObjectParameter("pIdSexo", typeof(int));
    
            var pIdTipoSangreParameter = pIdTipoSangre.HasValue ?
                new ObjectParameter("pIdTipoSangre", pIdTipoSangre) :
                new ObjectParameter("pIdTipoSangre", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarInstructores", pIdInstructorParameter, pNombreParameter, pPrimerApellidoParameter, pSegundoApellidoParameter, pCorreoParameter, pEdadParameter, pContraseñaParameter, pDireccionParameter, pTelefonoParameter, pTelefonoEmergenciaParameter, pCondicionesMedicasParameter, pIdEspecialidadParameter, pIdAdministradorParameter, pRolParameter, pIdSexoParameter, pIdTipoSangreParameter);
        }
    
        public virtual ObjectResult<MostrarListaResevas_Result> MostrarListaResevas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MostrarListaResevas_Result>("MostrarListaResevas");
        }
    
        public virtual ObjectResult<MostrarResevas_Result> MostrarResevas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MostrarResevas_Result>("MostrarResevas");
        }
    
        public virtual int RegistrarReserva(Nullable<int> claseID, Nullable<System.DateTime> dia, Nullable<System.TimeSpan> hora, Nullable<bool> equipo, string idCliente)
        {
            var claseIDParameter = claseID.HasValue ?
                new ObjectParameter("claseID", claseID) :
                new ObjectParameter("claseID", typeof(int));
    
            var diaParameter = dia.HasValue ?
                new ObjectParameter("dia", dia) :
                new ObjectParameter("dia", typeof(System.DateTime));
    
            var horaParameter = hora.HasValue ?
                new ObjectParameter("hora", hora) :
                new ObjectParameter("hora", typeof(System.TimeSpan));
    
            var equipoParameter = equipo.HasValue ?
                new ObjectParameter("equipo", equipo) :
                new ObjectParameter("equipo", typeof(bool));
    
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("idCliente", idCliente) :
                new ObjectParameter("idCliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarReserva", claseIDParameter, diaParameter, horaParameter, equipoParameter, idClienteParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<VerInstructores_Result> VerInstructores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VerInstructores_Result>("VerInstructores");
        }
    }
}
