using Api.Processos.Data.Context;
using Api.Processos.Data.Repositories;
using Api.Processos.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Teste
{
    public class ProcessoTeste : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public ProcessoTeste(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Teste da entidade TblProcessos")]
        public async Task E_Possivel_Realizar_Manipulacoes_TblProcessos()
        {
            using (var context = _serviceProvider.GetService<DataContext>())
            {
                ProcessosRepository _repositorio = new ProcessosRepository(context);
                TblProcessos entity = new TblProcessos
                {
                    DataInclusao = DateTime.UtcNow,
                    Escritorio = Faker.Company.Name(),
                    FlgAprovado = false,
                    FlgAtivo = true,
                    NomeReclamante = Faker.Name.FullName(),
                    NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                    ValorCausa = Faker.RandomNumber.Next()
                };
                var registroCriado = await _repositorio.InsertAsync(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal(entity.NomeReclamante, registroCriado.NomeReclamante);
                Assert.Equal(entity.NumeroProcesso, registroCriado.NumeroProcesso);

                entity.NomeReclamante = Faker.Name.First();
                var registroAtualizado = await _repositorio.UpdateAsync(entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.NumeroProcesso, registroAtualizado.NumeroProcesso);
                Assert.Equal(entity.NomeReclamante, registroAtualizado.NomeReclamante);

                var registroSelecionado = await _repositorio.SelectAsync(registroAtualizado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.NumeroProcesso, registroSelecionado.NumeroProcesso);
                Assert.Equal(registroAtualizado.NomeReclamante, registroSelecionado.NomeReclamante);

                var todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 0);

                var processoBuscado = await _repositorio.BuscarPorNumeroProcesso(registroSelecionado.NumeroProcesso);
                Assert.NotNull(processoBuscado);
                Assert.Equal(processoBuscado.NumeroProcesso, registroSelecionado.NumeroProcesso);
                Assert.Equal(processoBuscado.NomeReclamante, registroSelecionado.NomeReclamante);
            }
        }
    }
}
