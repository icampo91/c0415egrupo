using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.db
{
    public class GestorDB : DbContext
    {
        public GestorDB(): base("GestorDB")
        {
            Database.SetInitializer(new GestorDBInitializer());
        }
        public DbSet<Tipo> tipos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Atributo> atributos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
    }
}
