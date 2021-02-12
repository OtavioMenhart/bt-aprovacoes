using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoEditarProcesso : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível editar processo")]
        public async Task E_Possivel_Editar_Processo()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.CriarProcesso(processoDtoCreate)).ReturnsAsync(resultadoDtoSucesso);
            _service = _serviceMock.Object;

            var result = await _service.CriarProcesso(processoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(processoDtoCreate.NomeReclamante, result.processo.NomeReclamante);
            Assert.Equal(processoDtoCreate.NumeroProcesso, result.processo.NumeroProcesso);

            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.EditarProcesso(processoDtoUpdate)).ReturnsAsync(resultadoDtoSucessoUpdate);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.EditarProcesso(processoDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(resultadoDtoSucessoUpdate.processo.NomeReclamante, resultUpdate.processo.NomeReclamante);
            Assert.Equal(resultadoDtoSucessoUpdate.processo.NumeroProcesso, resultUpdate.processo.NumeroProcesso);
        }
    }
}
