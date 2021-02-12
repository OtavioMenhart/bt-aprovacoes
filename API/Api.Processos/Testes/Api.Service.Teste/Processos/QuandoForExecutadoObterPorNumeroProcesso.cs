using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoObterPorNumeroProcesso : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível obter processo por número do processo")]
        public async Task E_Possivel_Obter_Processo_Por_Numero_Processo()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.ObterPorNumeroProcesso(NumeroProcesso)).ReturnsAsync(tblProcessos);
            _service = _serviceMock.Object;

            var result = await _service.ObterPorNumeroProcesso(NumeroProcesso);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(result.NumeroProcesso, NumeroProcesso);
        }
    }
}
