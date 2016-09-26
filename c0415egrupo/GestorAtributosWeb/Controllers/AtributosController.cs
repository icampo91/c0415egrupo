using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using GestorAtributos.repositories;
using GestorAtributos.servicio;
using GestorAtributos.utils;
using Microsoft.Practices.Unity;
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
        private IAtributoService sut;
        public AtributosController()
        {
            var container = new UnityContainer();
            container.RegisterType<IAtributoRepository, AtributoRepository>();
            container.RegisterInstance<IAtributoUtil>(new AtributoUtil());
            container.RegisterType<IAtributoService, AtributoService>();
            sut = container.Resolve<AtributoService>();
        }
        // GET: api/Atributos
        public ICollection<AtributoVO> Get()
        {
            return sut.Get();
        }

        // GET: api/Atributos/5
        public AtributoVO Get(int id)
        {
            return sut.Get(id);
        }

        // POST: api/Atributos
        public AtributoVO Post([FromBody]AtributoVO _atrivutoVO)
        {
            return sut.Post(_atrivutoVO);
        }

        // PUT: api/Atributos/5
        public AtributoVO Put(int id, [FromBody]AtributoVO _atrivutoVO)
        {
            return sut.Put(_atrivutoVO);
        }

        // DELETE: api/Atributos/5
        public Boolean Delete(int id)
        {
            return sut.Delete(id);
        }
    }
}
