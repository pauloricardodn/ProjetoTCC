using System.Net.Http;

namespace ProjetoHortFrut.Application.Interfaces
{
    public interface IEstadoAppService
    {
        HttpResponseMessage GetAllEstados();
    }
}
