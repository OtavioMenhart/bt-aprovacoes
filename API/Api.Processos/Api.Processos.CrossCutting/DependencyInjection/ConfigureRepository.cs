using Api.Processos.Data.Context;
using Api.Processos.Data.Repositories;
using Api.Processos.Domain.Interfaces;
using Api.Processos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Processos.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DataContext>(
                options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;database=ProcessosBD;Trusted_Connection=True;")
                );
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IProcessosRepository, ProcessosRepository>();
        }
    }
}
