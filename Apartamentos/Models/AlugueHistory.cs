using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartamentos.Models
{
    public class AlugueHistory
    {
        [Key]
        public string AIdentificador { get; set; }

        public string Descripcion { get; set; }

        public int PersonaID { get; set; }

        public int Precio { get; set; }

        public string FechaSalida { get; set; }

        public string FechaInicio { get; set; }

        public string Foto1 { get; set; }

        public string Foto2 { get; set; }

        public string Foto3 { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual ICollection<CuentasHistory> CuentasHistory { get; set; }





    }
}