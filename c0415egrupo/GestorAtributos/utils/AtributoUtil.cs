using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.utils
{
    public class AtributoUtil : IAtributoUtil
    {
        public Atributo ConvierteVO2Entity(AtributoVO _atrivutoVO)
        {

            Atributo res = new Atributo();
            res.id = _atrivutoVO.id;
            res.codigo = _atrivutoVO.codigo;
            res.nombre = _atrivutoVO.nombre;
            res.tipoID = _atrivutoVO.tipoID;
            res.categoriaID = _atrivutoVO.categoriaID;
            res.descripcion = _atrivutoVO.descripcion;
            return res;

        }

        public AtributoVO ConvierteEntity2VO(Atributo _atrivuto)
        {
            AtributoVO res = new AtributoVO();
            res.id = _atrivuto.id;
            res.codigo = _atrivuto.codigo;
            res.nombre = _atrivuto.nombre;
            res.tipoID = _atrivuto.tipoID;
            res.categoriaID = _atrivuto.categoriaID;
            res.descripcion = _atrivuto.descripcion;
            return res;
        }
        public AtributoVO ConvierteEntity2VOTotal(Atributo _atrivuto)
        {
            AtributoVO res = new AtributoVO();
            TipoVO tvo = new TipoVO(_atrivuto.tipo.id, _atrivuto.tipo.nombre);
            CategoriaVO cvo = new CategoriaVO(_atrivuto.categoria.id, _atrivuto.categoria.nombre);
            res.id = _atrivuto.id;
            res.codigo = _atrivuto.codigo;
            res.nombre = _atrivuto.nombre;
            res.tipoID = _atrivuto.tipoID;
            res.tipoVO = tvo;
            res.categoriaID = _atrivuto.categoriaID;
            res.categoriaVO = cvo;
            res.descripcion = _atrivuto.descripcion;
            return res;

        }
    }
}
