using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Apartamentos.Models
{
    public class AptContext : DbContext
    {
        public AptContext() : base("DefaultConnection")
        {

        }

        public DbSet<Persona> Persona { get; set; }

        public DbSet<Apt> Apt { get; set; }

        public DbSet<AptSolo> AptSolo { get; set; }

        public DbSet<AlugueHistory> AlugueHistory { get; set; }

        public DbSet<Cuentas> Cuentas { get; set; }

        public DbSet<CuentasHistory> CuentasHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}