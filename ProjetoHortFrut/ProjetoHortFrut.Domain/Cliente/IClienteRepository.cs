﻿using System.Collections.Generic;

namespace ProjetoHortFrut.Domain.Clientes
{
    public interface IClienteRepository
    {
        void PostCliente(ClienteDto cliente);
        ClienteDto GetByClienteId(int id);
        IEnumerable<ClienteDto> GetAllClientes(int op);
        ClienteDto GetClienteByCpf(string cpf);
        void PutClientes(ClienteDto cliente);
    }
}
