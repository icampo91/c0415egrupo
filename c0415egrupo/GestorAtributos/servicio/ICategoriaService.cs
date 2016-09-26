using System.Collections.Generic;
using GestorAtributos.objetoVO;

namespace GestorCategorias.servicio
{
    public interface ICategoriaService
    {
        bool Delete(int _id);
        ICollection<CategoriaVO> Get();
        CategoriaVO Get(int _id);
        CategoriaVO Post(CategoriaVO _categoriaVO);
        CategoriaVO Put(CategoriaVO _categoriaVO);
    }
}