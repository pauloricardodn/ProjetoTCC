using ProjetoHortFrut.Application;
using ProjetoHortFrut.Application.Interfaces;
using SimpleInjector;
namespace ProjetoHortFrut.MVC.App_Start
{
    public static class SimpleInjectorContainerMvc
    {
        public static Container RegisterServices()
        {

            var container = new Container();            

            container.Register<IClienteAppService, ClienteAppService>();
           
            container.Register<IUsuarioAppService, UsuarioAppService>();

            container.Verify();

            return container;
        }
    }
}