using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ProyectoProgra4.Models
{
    public class RegistrarModel
    {
        public clsUsuario RegistrarUsuario(string cedula)
        {
            clsUsuario cls = new clsUsuario();
            using (var cliente = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlConsultaPersonas"] + cedula;
                HttpResponseMessage response = cliente.GetAsync(url).Result;
                if (response.IsSuccessStatusCode && cedula.Length == 9)
                {
                    var resultado = response.Content.ReadAsAsync<clsUsuario>().Result;
                    return resultado;
                }
            }
            return cls;
        }
    }
}