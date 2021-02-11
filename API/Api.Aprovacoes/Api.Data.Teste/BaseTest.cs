using Api.Processos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Teste
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }
    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(x => x.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;database={dataBaseName};"), ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<DataContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {

            using (var context = ServiceProvider.GetService<DataContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
