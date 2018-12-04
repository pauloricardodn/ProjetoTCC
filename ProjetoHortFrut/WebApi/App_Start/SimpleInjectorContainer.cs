using ProjetoHortFrut.Domain.Cidade;
using ProjetoHortFrut.Domain.Cidades;
using ProjetoHortFrut.Domain.Clientes;
using ProjetoHortFrut.Domain.Entities;
using ProjetoHortFrut.Domain.Estados;
using ProjetoHortFrut.Domain.Usuarios;
using ProjetoHortFrut.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Web_Api
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();            

            container.Register<IClienteRepository, ClientesRepository>();
            container.Register<IClienteService, ClienteService>();
            
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IUsuarioService, UsuarioService>();

            container.Register<ICidadeRepository, CidadeRepository>();
            container.Register<ICidadeService, CidadeService>();

            container.Register<IEstadoRepository, EstadoRepository>();
            container.Register<IEstadoService, EstadoService>();

            container.Register<Notifications>(Lifestyle.Scoped);

            container.Register<Conexao>(Lifestyle.Scoped);

            container.Verify();

            return container;

        }
    }
}