using System.Collections.Generic;
using GestorAtributos.objeto;

namespace GestorTipos.repositories
{
    public interface ITipoRepository
    {
        bool Delete(int _id);
        Tipo Get(int _id);
        ICollection<Tipo> Get();
        Tipo Put(Tipo _tipo);
        Tipo Post(Tipo _tipo);
    }
}