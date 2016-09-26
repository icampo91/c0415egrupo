using GestorAtributos.db;
using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTipos.repositories
{
    public class TipoRepository : ITipoRepository
    {
        public Tipo Get(int _id)
        {
            Tipo res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.tipos.Find(_id);
            }
            return res;
        }

        public Tipo Post(Tipo _tipo)
        {
            Tipo res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.tipos.Add(_tipo);
                gestorDB.SaveChanges();
            }
            return res;
        }

        public Boolean Delete(int _id)
        {
            Boolean respuesta = true;
            using (var gestorDB = new GestorDB())
            {
                Tipo a = gestorDB.tipos.Find(_id);
                try{
                gestorDB.tipos.Remove(a);
                gestorDB.SaveChanges();
                }
                catch{
                    respuesta = false;
                    return respuesta;
                }
            }
            return respuesta;
        }
        

        public Tipo Put(Tipo _tipo)
        {
            Tipo res = null;
            using (var gestorDB = new GestorDB())
            {
                res=gestorDB.tipos.Attach(_tipo);
                gestorDB.Entry(_tipo).State = System.Data.Entity.EntityState.Modified;
                gestorDB.SaveChanges();
            }
            return res;
        }
        public ICollection<Tipo> Get()
        {
            ICollection<Tipo> res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.tipos.ToList<Tipo>();

            }
            return res;
        }
    }
}
