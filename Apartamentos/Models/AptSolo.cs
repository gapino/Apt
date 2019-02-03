using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartamentos.Models
{
    public class AptSolo
    {
        public int AptSoloID { get; set; }

        public string Descripcion { get; set; }

        public int Precio { get; set; }
        public bool Alugado { get; set; }

        public string Foto1 { get; set; }

        public string Foto2 { get; set; }

        public string Foto3 { get; set; }
    }
}