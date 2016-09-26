using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.objetoVO
{
    public class TipoVO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public TipoVO()
        {

        }
        public TipoVO(string _nombre)
        {
            this.nombre = _nombre;

        }
        public TipoVO(int _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }
    }
}
