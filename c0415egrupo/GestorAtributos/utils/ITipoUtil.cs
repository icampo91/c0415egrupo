using GestorAtributos.objeto;
using GestorAtributos.objetoVO;

namespace GestorTipos.utils
{
    public interface ITipoUtil
    {
        TipoVO ConvierteEntity2VO(Tipo _tipo);
        Tipo ConvierteVO2Entity(TipoVO _tipoVO);
    }
}