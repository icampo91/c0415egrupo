using GestorAtributos.objetoVO;
using GestorCategorias.repositories;
using GestorCategorias.servicio;
using GestorCategorias.utils;
using Microsoft.Practices.Unity;
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
        private ICategoriaService sut;
        public CategoriasController()
        {
            var container = new UnityContainer();
            container.RegisterType<ICategoriaRepository, CategoriaRepository>();
            container.RegisterInstance<ICategoriaUtil>(new CategoriaUtil());
            container.RegisterType<ICategoriaService, CategoriaService>();
            sut = container.Resolve<CategoriaService>();
        }
        // GET: api/Categorias
        public ICollection<CategoriaVO> Get()
        {
            return sut.Get();
        }

        // GET: api/Categorias/5
        public CategoriaVO Get(int id)
        {
            return sut.Get(id);
        }

        // POST: api/Categorias
        public CategoriaVO Post([FromBody]CategoriaVO _atrivutoVO)
        {
            return sut.Post(_atrivutoVO);
        }

        // PUT: api/Categorias/5
        public CategoriaVO Put(int id, [FromBody]CategoriaVO _atrivutoVO)
        {
            return sut.Put(_atrivutoVO);
        }

        // DELETE: api/Categorias/5
        public Boolean Delete(int id)
        {
            return sut.Delete(id);
        }
    }
}
