using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCategorias.utils
{
    public class CategoriaUtil : ICategoriaUtil
    {
        public Categoria ConvierteVO2Entity(CategoriaVO _categoriaVO)
        {

            Categoria res = new Categoria();
            res.id = _categoriaVO.id;
            res.nombre = _categoriaVO.nombre;
            return res;

        }

        public CategoriaVO ConvierteEntity2VO(Categoria _categoria)
        {
            CategoriaVO res = new CategoriaVO();
            res.id = _categoria.id;
            res.nombre = _categoria.nombre;
            return res;
        }
        
    }
}