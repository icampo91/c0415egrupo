using GestorAtributos.objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestorAtributosWeb.Controllers
{
    public class AtributosController : ApiController
    {
        // GET: api/Atributos
        public IEnumerable<Atributo> Get()
        {
            return new Atributo[] {
                new Atributo() { id = 1, codigo = "A1", nombre = "Primer Atributo", descripcion = "Primera Descripcion", tipoID = 1, categoriaID = 1 },
                new Atributo() { id = 2, codigo = "A2", nombre = "Segundo Atributo", descripcion = "Sengunda Descripcion", tipoID = 2, categoriaID = 2 },
                new Atributo() { id = 3, codigo = "A3", nombre = "Tercero Atributo", descripcion = "Tercera Descripcion", tipoID = 3, categoriaID = 3 },
            };
        }

        // GET: api/Atributos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Atributos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Atributos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Atributos/5
        public void Delete(int id)
        {
        }
    }
}
