using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcialUno.Models
{
    public class Prestamo
    {
        public Int64 PrestamoId { get; set; }
        public Int64 UsuarioCedula { get; set; }
        public Int64 VideoJuegoCodigo { get; set; }
        public Int64 VideoJuegoCodigoEjemplar { get; set; }
        public DateTime PrestamoFechaRegistro { get; set; }
        public bool EsDevuelto { get; set; }
    }
}