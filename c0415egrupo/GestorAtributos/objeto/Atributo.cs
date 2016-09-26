using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.objeto
{
    public class Atributo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int tipoID { get; set; }
        [ForeignKey("tipoID")]
        public virtual Tipo tipo { get; set; }
        public int categoriaID { get; set; }
        [ForeignKey("categoriaID")]
        public virtual Categoria categoria { get; set; }
        public string descripcion { get; set; }

        public Atributo() { }

        public Atributo(string _codigo,string _nombre,int _tipoID,int _categoriaID,string _descripcion)
        {
            this.codigo = _codigo;
            this.nombre = _nombre;
            this.tipoID = _tipoID;
            this.categoriaID = _categoriaID;
            this.descripcion = _descripcion;
        }
        public Atributo(int _id,string _codigo, string _nombre, int _tipoID, int _categoriaID, string _descripcion)
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
