using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestorAtributosWeb.Controllers
{
    public class TiposController : ApiController
    {
        // GET: api/Tipos
        public IEnumerable<Tipo> Get()
        {
            return new Tipo[] {
                new Tipo() { id=1, nombre="Primer Tipo" },
                new Tipo() { id=2, nombre="Segundo Tipo" },
                new Tipo() { id=3, nombre="Tercer Tipo" },
            };
        }

        // GET: api/Tipos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tipos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tipos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tipos/5
        public void Delete(int id)
        {
        }
    }
}
