using GestorAtributos.db;
using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.repositories
{
    public class AtributoRepository : IAtributoRepository
    {
        public Atributo Get(int _id)
        {
            Atributo res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.atributos.Find(_id);
            }
            return res;
        }

        public Atributo Post(Atributo _atributo)
        {
            Atributo res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.atributos.Add(_atributo);
                gestorDB.SaveChanges();
            }
            return res;
        }

        public Boolean Delete(int _id)
        {
            Boolean respuesta = true;
            using (var gestorDB = new GestorDB())
            {
                Atributo a = gestorDB.atributos.Find(_id);
                try{
                gestorDB.atributos.Remove(a);
                gestorDB.SaveChanges();
                }
                catch{
                    respuesta = false;
                    return respuesta;
                }
            }
            return respuesta;
        }
        

        public Atributo Put(Atributo _atributo)
        {
            Atributo res = null;
            using (var gestorDB = new GestorDB())
            {
                res=gestorDB.atributos.Attach(_atributo);
                gestorDB.Entry(_atributo).State = System.Data.Entity.EntityState.Modified;
                gestorDB.SaveChanges();
            }
            return res;
        }
        public ICollection<Atributo> Get()
        {
            ICollection<Atributo> res = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.atributos.Include("Tipo").Include("Categoria").ToList<Atributo>();
            }
            return res;
        }

        public ICollection<Atributo> Get(string _codigo)
        {
            ICollection<Atributo> res = null;
            List<Atributo> res2 = null;
            using (var gestorDB = new GestorDB())
            {
                res = gestorDB.atributos.Include("Tipo").Include("Categoria").ToList<Atributo>();
                res2 = new List<Atributo>();
                foreach (Atributo a in res)
                {
                    if (a.codigo.ToUpper().Contains(_codigo))
                    {
                        res2.Add(a);
                    }
                }
            }
            return res2;
        }
    }
}
