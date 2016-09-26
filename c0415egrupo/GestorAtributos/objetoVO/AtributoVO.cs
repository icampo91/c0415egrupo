using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.objetoVO
{
    public class AtributoVO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int tipoID { get; set; }
        public virtual TipoVO tipoVO { get; set; }
        public int categoriaID { get; set; }
        public virtual CategoriaVO categoriaVO { get; set; }
        public string descripcion { get; set; }
        public AtributoVO() { }

        public AtributoVO(string _codigo, string _nombre, int _tipoID, int _categoriaID, string _descripcion)
        {
            this.codigo = _codigo;
            this.nombre = _nombre;
            this.tipoID = _tipoID;
            this.categoriaID = _categoriaID;
            this.descripcion = _descripcion;
        }
        public AtributoVO(int _id, string _codigo, string _nombre, int _tipoID, int _categoriaID, string _descripcion)
        {
            this.id = _id;
            this.codigo = _codigo;
            this.nombre = _nombre;
            this.tipoID = _tipoID;
            this.categoriaID = _categoriaID;
            this.descripcion = _descripcion;
        }
    }
}
