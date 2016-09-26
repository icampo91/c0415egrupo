using System.Collections.Generic;
using GestorAtributos.objetoVO;

namespace GestorTipos.servicio
{
    public interface ITipoService
    {
        bool Delete(int _id);
        ICollection<TipoVO> Get();
        TipoVO Get(int _id);
        TipoVO Post(TipoVO _tipoVO);
        TipoVO Put(TipoVO _tipoVO);
    }
}