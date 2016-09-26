using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.objeto
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Categoria()
        {

        }
        public Categoria(string _nombre)
        {
            this.nombre = _nombre;

        }
        public Categoria(int _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }
    }
}
