using System.Collections.Generic;

namespace ProjetoHortFrut.Domain.Cidades
{
    public interface ICidadeRepository
    {
        IEnumerable<Cidade> GetCidadesByEstadoId(int id);
    }
}
