using GestorAtributos.objeto;
using GestorAtributos.objetoVO;
using GestorTipos.repositories;
using GestorTipos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTipos.servicio
{
    public class TipoService : ITipoService
    {
        ITipoRepository tipoRepository;
        private ITipoUtil tipoUtil;

        public TipoService(ITipoRepository _tipoRepository, ITipoUtil _tipoUtil)
        {
            this.tipoRepository = _tipoRepository;
            this.tipoUtil = _tipoUtil;
        }
        public TipoVO Post(TipoVO _tipoVO)
        {
            Tipo tipo = tipoUtil.ConvierteVO2Entity(_tipoVO);
            tipo = this.tipoRepository.Post(tipo);
            TipoVO res = tipoUtil.ConvierteEntity2VO(tipo);
            return res;
        }
        public Boolean Delete(int _id)
        {
           return this.tipoRepository.Delete(_id);
        }
        public TipoVO Get(int _id)
        {
            Tipo tipo = this.tipoRepository.Get(_id);
            TipoVO tipoVO = tipoUtil.ConvierteEntity2VO(tipo);
            return tipoVO;
        }
        public TipoVO Put(TipoVO _tipoVO)
        {
            Tipo tipo = tipoUtil.ConvierteVO2Entity(_tipoVO);
            tipo=this.tipoRepository.Put(tipo);
            TipoVO res = tipoUtil.ConvierteEntity2VO(tipo);
            return res;
        }
        public ICollection<TipoVO> Get()
        {
            ICollection<TipoVO> res = new List<TipoVO>();
            foreach (Tipo v in tipoRepository.Get())
            {
                TipoVO anadir = tipoUtil.ConvierteEntity2VO(v);
                res.Add(anadir);
            }
            return res;
        }
    }
}
