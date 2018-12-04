using ProjetoHortFrut.Domain.Clientes;
using System.Net.Http;

namespace ProjetoHortFrut.Application.Interfaces
{
    public interface IClienteAppService
    {
        HttpResponseMessage PostCliente(ClienteDto cliente);
        HttpResponseMessage GetByClienteId(int id);
        HttpResponseMessage GetAllClientes(int op);
        HttpResponseMessage GetClienteByCpf(string cpf);
        HttpResponseMessage PutCliente(ClienteDto cliente);
    }
}
