using System.Collections.Generic;

namespace ProjetoHortFrut.Domain.Estados
{
    public interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
    }
}
