using GestorAtributos.objeto;
using GestorAtributos.objetoVO;

namespace GestorAtributos.utils
{
    public interface IAtributoUtil
    {
        AtributoVO ConvierteEntity2VO(Atributo _atrivuto);
        AtributoVO ConvierteEntity2VOTotal(Atributo _atrivuto);
        Atributo ConvierteVO2Entity(AtributoVO _atrivutoVO);
    }
}