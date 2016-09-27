using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using GestorTipos.repositories;
using GestorTipos.servicio;
using GestorTipos.utils;
using Microsoft.Practices.Unity;
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
        private ITipoService sut;
        public TiposController()
        {
            var container = new UnityContainer();
            container.RegisterType<ITipoRepository, TipoRepository>();
            container.RegisterInstance<ITipoUtil>(new TipoUtil());
            container.RegisterType<ITipoService, TipoService>();
            sut = container.Resolve<TipoService>();
        }
        // GET: api/Tipos
        public ICollection<TipoVO> Get()
        {
            return sut.Get();
        }

        // GET: api/Tipos/5
        public TipoVO Get(int id)
        {
            return sut.Get(id);
        }

        // POST: api/Tipos
        public TipoVO Post([FromBody]TipoVO _atrivutoVO)
        {
            return sut.Post(_atrivutoVO);
        }

        // PUT: api/Tipos/5
        public TipoVO Put(int id, [FromBody]TipoVO _atrivutoVO)
        {
            return sut.Put(_atrivutoVO);
        }

        // DELETE: api/Tipos/5
        public Boolean Delete(int id)
        {
            return sut.Delete(id);
        }
    }
}
