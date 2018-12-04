using System.Collections.Generic;

namespace ProjetoHortFrut.Domain.Estados
{
    public interface IEstadoRepository
    {
        IEnumerable<Estado> GetAllEstados();
    }
}
