using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoAlterarStatusProcesso : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível alterar status do processo")]
        public async Task E_Possivel_Alterar_Status_Processo()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.CriarProcesso(processoDtoCreate)).ReturnsAsync(resultadoDtoSucesso);
            _service = _serviceMock.Object;

            var result = await _service.CriarProcesso(processoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(processoDtoCreate.NomeReclamante, result.processo.NomeReclamante);
            Assert.Equal(processoDtoCreate.NumeroProcesso, result.processo.NumeroProcesso);

            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.AlterarStatusProcesso(statusProcesso)).ReturnsAsync(resultadoStatusDto);
            _service = _serviceMock.Object;

            var resultAlteracaoStatus = await _service.AlterarStatusProcesso(statusProcesso);
            Assert.NotNull(resultAlteracaoStatus);
            Assert.Equal(resultadoStatusDto.processo.NomeReclamante, resultAlteracaoStatus.processo.NomeReclamante);
            Assert.Equal(resultadoStatusDto.processo.NumeroProcesso, resultAlteracaoStatus.processo.NumeroProcesso);
            Assert.True(resultadoStatusDto.processo.FlgAprovado);
            Assert.True(resultAlteracaoStatus.processo.FlgAprovado);
        }
    }
}
