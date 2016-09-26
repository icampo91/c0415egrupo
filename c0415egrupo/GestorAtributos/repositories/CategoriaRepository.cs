using GestorAtributos.db;
using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCategorias.repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public Categoria Get(int _id)
        {
            Categoria res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.categorias.Find(_id);
            }
            return res;
        }

        public Categoria Post(Categoria _categoria)
        {
            Categoria res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.categorias.Add(_categoria);
                gestorDB.SaveChanges();
            }
            return res;
        }

        public Boolean Delete(int _id)
        {
            Boolean respuesta = true;
            using (var gestorDB = new GestorDB())
            {
                Categoria a = gestorDB.categorias.Find(_id);
                try{
                gestorDB.categorias.Remove(a);
                gestorDB.SaveChanges();
                }
                catch{
                    respuesta = false;
                    return respuesta;
                }
            }
            return respuesta;
        }
        

        public Categoria Put(Categoria _categoria)
        {
            Categoria res = null;
            using (var gestorDB = new GestorDB())
            {
                res=gestorDB.categorias.Attach(_categoria);
                gestorDB.Entry(_categoria).State = System.Data.Entity.EntityState.Modified;
                gestorDB.SaveChanges();
            }
            return res;
        }
        public ICollection<Categoria> Get()
        {
            ICollection<Categoria> res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.categorias.ToList<Categoria>();

            }
            return res;
        }
    }
}
