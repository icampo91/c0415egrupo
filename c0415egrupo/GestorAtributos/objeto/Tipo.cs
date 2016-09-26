using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.objeto
{
    public class Tipo
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Tipo()
        {

        }
        public Tipo(string _nombre)
        {
            this.nombre = _nombre;

        }
        public Tipo(int _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }
    }
}
