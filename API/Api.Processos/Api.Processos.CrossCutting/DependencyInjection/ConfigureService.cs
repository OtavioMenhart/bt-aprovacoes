using Api.Processos.Domain.Interfaces.Services;
using Api.Processos.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Processos.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProcessoService, ProcessoService>();
        }
    }
}
