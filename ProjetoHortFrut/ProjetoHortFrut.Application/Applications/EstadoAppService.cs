using ProjetoHortFrut.Application.Interfaces;
using System.Net.Http;
using Web_Api.Utilitarios;

namespace ProjetoHortFrut.Application
{
    public class EstadoAppService : IEstadoAppService
    {
        public HttpResponseMessage GetAllEstados()
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Estados")
                .GetAsync("GetAllEstados").Result;
            return response;
        }

    }
}
