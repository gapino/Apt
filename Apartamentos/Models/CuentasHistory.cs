using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartamentos.Models
{
    public class CuentasHistory
    {
        [Key]
        public int CuentasID { get; set; }

        public string Tipo { get; set; }

        public int Monto { get; set; }

        public string fecha { get; set; }

        public string AIdentificador { get; set; }

        public virtual AlugueHistory AlugueHistory { get; set; }
    }
}