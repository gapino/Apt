using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartamentos.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        public string Nombre { get; set; }

        public int Rg { get; set; }

        public long Cpf { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Apt> Apt { get; set; }

        public virtual ICollection<AlugueHistory> AlugueHistory { get; set; }

    }
}