﻿using System.Collections.Generic;

namespace ProjetoHortFrut.Domain.Cidade
{
    public interface ICidadeService
    {
        IEnumerable<Cidades.Cidade> GetCidadesByEstadoId(int id);
    }
}
