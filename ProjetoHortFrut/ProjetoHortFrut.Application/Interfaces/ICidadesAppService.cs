using System.Net.Http;

namespace ProjetoHortFrut.Application.Interfaces
{
    public interface ICidadesAppService
    {
        HttpResponseMessage GetCidadesByEstadoId(int id);
    }
}
