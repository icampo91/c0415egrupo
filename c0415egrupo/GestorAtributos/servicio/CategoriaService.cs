
using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using GestorCategorias.repositories;
using GestorCategorias.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCategorias.servicio
{
    public class CategoriaService
    {
        ICategoriaRepository categoriaRepository;
        private ICategoriaUtil categoriaUtil;

        public CategoriaService(ICategoriaRepository _categoriaRepository, ICategoriaUtil _categoriaUtil)
        {
            this.categoriaRepository = _categoriaRepository;
            this.categoriaUtil = _categoriaUtil;
        }
        public CategoriaVO Post(CategoriaVO _categoriaVO)
        {
            Categoria categoria = categoriaUtil.ConvierteVO2Entity(_categoriaVO);
            categoria = this.categoriaRepository.Post(categoria);
            CategoriaVO res = categoriaUtil.ConvierteEntity2VO(categoria);
            return res;
        }
        public Boolean Delete(int _id)
        {
           return this.categoriaRepository.Delete(_id);
        }
        public CategoriaVO Get(int _id)
        {
            Categoria categoria = this.categoriaRepository.Get(_id);
            CategoriaVO categoriaVO = categoriaUtil.ConvierteEntity2VO(categoria);
            return categoriaVO;
        }
        public CategoriaVO Modifica(CategoriaVO _categoriaVO)
        {
            Categoria categoria = categoriaUtil.ConvierteVO2Entity(_categoriaVO);
            categoria=this.categoriaRepository.Put(categoria);
            CategoriaVO res = categoriaUtil.ConvierteEntity2VO(categoria);
            return res;
        }
        public ICollection<CategoriaVO> Get()
        {
            ICollection<CategoriaVO> res = new List<CategoriaVO>();
            foreach (Categoria v in categoriaRepository.Get())
            {
                CategoriaVO anadir = categoriaUtil.ConvierteEntity2VO(v);
                res.Add(anadir);
            }
            return res;
        }
    }
}
