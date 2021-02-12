using Api.Processos.Data.Context;
using Api.Processos.Data.Repositories;
using Api.Processos.Domain.Interfaces;
using Api.Processos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Processos.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DataContext>(
                options => options.UseSqlServer("Server=den1.mssql7.gear.host;database=aprovacoesbd;User Id=aprovacoesbd;password=Us4f~-ft2ou7")
                );
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IProcessosRepository, ProcessosRepository>();
        }
    }
}
