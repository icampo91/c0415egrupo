using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTipos.utils
{
    public class TipoUtil : ITipoUtil
    {
        public Tipo ConvierteVO2Entity(TipoVO _tipoVO)
        {

            Tipo res = new Tipo();
            res.id = _tipoVO.id;
            res.nombre = _tipoVO.nombre;
            return res;

        }

        public TipoVO ConvierteEntity2VO(Tipo _tipo)
        {
            TipoVO res = new TipoVO();
            res.id = _tipo.id;
            res.nombre = _tipo.nombre;
            return res;
        }
        
    }
}