﻿using System.Collections.Generic;
using GestorAtributos.objeto;

namespace GestorAtributos.repositories
{
    public interface IAtributoRepository
    {
        bool Delete(int _id);
        Atributo Get(int _id);
        ICollection<Atributo> Get();
        Atributo Put(Atributo _atributo);
        Atributo Post(Atributo _atributo);
    }
}