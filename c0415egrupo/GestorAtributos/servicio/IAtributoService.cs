using System.Collections.Generic;
using GestorAtributos.objetoVO;

namespace GestorAtributos.servicio
{
    public interface IAtributoService
    {
        bool Delete(int _id);
        ICollection<AtributoVO> Get();
        AtributoVO Get(int _id);
        AtributoVO Post(AtributoVO _atributoVO);
        AtributoVO Put(AtributoVO _atributoVO);
    }
}