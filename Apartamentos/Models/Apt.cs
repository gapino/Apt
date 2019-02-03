using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apartamentos.Models
{
    public class Apt
    {
        [Key]
        public string AptsIdentificador { get; set; }

        public string Descripcion { get; set; }

        public int PersonaID { get; set; }

        public int Precio { get; set; }

        
        public string FechaInicio { get; set; }

        public string Foto1 { get; set; }

        public string Foto2 { get; set; }

        public string Foto3 { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual ICollection<Cuentas> Cuentas { get; set; }

    }
}