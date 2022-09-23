using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcialUno.Models
{
    public class Usuario
    {
        public Int64 UsuarioCedula { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public string UsuarioCorreo { get; set; }
    }
}