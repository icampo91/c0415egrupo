using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using GestorAtributos.repositories;
using GestorAtributos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAtributos.servicio
{
    public class AtributoService
    {
        IAtributoRepository atributoRepository;
        private IAtributoUtil atributoUtil;

        public AtributoService(IAtributoRepository _atributoRepository, IAtributoUtil _atributoUtil)
        {
            this.atributoRepository = _atributoRepository;
            this.atributoUtil = _atributoUtil;
        }
        public AtributoVO Post(AtributoVO _atributoVO)
        {
            Atributo atributo = atributoUtil.ConvierteVO2Entity(_atributoVO);
            atributo = this.atributoRepository.Post(atributo);
            AtributoVO res = atributoUtil.ConvierteEntity2VO(atributo);
            return res;
        }
        public Boolean Delete(int _id)
        {
           return this.atributoRepository.Delete(_id);
        }
        public AtributoVO Get(int _id)
        {
            Atributo atributo = this.atributoRepository.Get(_id);
            AtributoVO atributoVO = atributoUtil.ConvierteEntity2VO(atributo);
            return atributoVO;
        }
        public AtributoVO Modifica(AtributoVO _atributoVO)
        {
            Atributo atributo = atributoUtil.ConvierteVO2Entity(_atributoVO);
            atributo=this.atributoRepository.Put(atributo);
            AtributoVO res = atributoUtil.ConvierteEntity2VO(atributo);
            return res;
        }
        public ICollection<AtributoVO> Get()
        {
            ICollection<AtributoVO> res = new List<AtributoVO>();
            foreach (Atributo v in atributoRepository.Get())
            {
                AtributoVO anadir = atributoUtil.ConvierteEntity2VOTotal(v);
                res.Add(anadir);
            }
            return res;
        }
    }
}
