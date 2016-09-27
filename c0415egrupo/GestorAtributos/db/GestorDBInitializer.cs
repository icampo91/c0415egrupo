using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.db
{
    public class GestorDBInitializer : DropCreateDatabaseAlways<GestorDB>
    {
        protected override void Seed(GestorDB context)
        {

            context.tipos.Add(new Tipo("String"));
            context.tipos.Add(new Tipo("Integer"));
            context.tipos.Add(new Tipo("Double"));
            context.tipos.Add(new Tipo("Boolean"));

            context.categorias.Add(new Categoria("Expediente"));
            context.categorias.Add(new Categoria("Informes"));

            context.SaveChanges();

            context.atributos.Add(new Atributo("ATR1", "Atributo_1", 2, 1, "Desc..."));
            context.atributos.Add(new Atributo("ATR2", "Atributo_2", 4, 2, "Desc..."));

            base.Seed(context);
        }
    }
}
