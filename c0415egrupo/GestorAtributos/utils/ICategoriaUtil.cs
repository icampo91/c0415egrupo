using GestorAtributos.objeto;
using GestorAtributos.objetoVO;

namespace GestorCategorias.utils
{
    public interface ICategoriaUtil
    {
        CategoriaVO ConvierteEntity2VO(Categoria _categoria);
        Categoria ConvierteVO2Entity(CategoriaVO _categoriaVO);
    }
}