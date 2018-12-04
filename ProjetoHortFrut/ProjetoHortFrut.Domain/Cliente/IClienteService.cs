namespace ProjetoHortFrut.Domain.Clientes
{
    public interface IClienteService
    {
        ClienteDto GetByClienteId(int id);
        ClienteDto GetClienteByCpf(string cpf);
    }
}
