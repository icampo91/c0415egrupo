using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestorAtributosWeb.Controllers
{
    public class CategoriasController : ApiController
    {
        // GET: api/Categorias
        public IEnumerable<Categoria> Get()
        {
            return new Categoria[] {
                new Categoria() { id=1, nombre="Primera Categoria" },
                new Categoria() { id=2, nombre="Segunda Categoria" },
                new Categoria() { id=3, nombre="Tercera Categoria" },
            };
        }

        // GET: api/Categorias/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categorias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categorias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categorias/5
        public void Delete(int id)
        {
        }
    }
}
