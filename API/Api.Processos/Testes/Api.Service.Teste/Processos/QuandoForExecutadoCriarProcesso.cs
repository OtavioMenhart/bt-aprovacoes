using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoCriarProcesso : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível criar processo")]
        public async Task E_Possivel_Criar_Processo()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.CriarProcesso(processoDtoCreate)).ReturnsAsync(resultadoDtoSucesso);
            _service = _serviceMock.Object;

            var result = await _service.CriarProcesso(processoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(processoDtoCreate.NomeReclamante, result.processo.NomeReclamante);
            Assert.Equal(processoDtoCreate.NumeroProcesso, result.processo.NumeroProcesso);
        }
    }
}
