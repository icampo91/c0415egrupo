using System.Collections.Generic;
using GestorAtributos.objeto;

namespace GestorCategorias.repositories
{
    public interface ICategoriaRepository
    {
        bool Delete(int _id);
        Categoria Get(int _id);
        ICollection<Categoria> Get();
        Categoria Put(Categoria _categoria);
        Categoria Post(Categoria _categoria);
    }
}