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
        private IProcessoService _service;
        private Mock<IProcessoService> _serviceMock;

        [Fact(DisplayName = "É possível obter processo por número do processo")]
        public async Task E_Possivel_Obter_Processo_Por_Numero_Processo()
        {
            _serviceMock = new Mock<IProcessoService>();
            _serviceMock.Setup(x => x.ObterPorNumeroProcesso(NumeroProcesso)).ReturnsAsync(tblProcessos);
            _service = _serviceMock.Object;

            var result = await _service.ObterPorNumeroProcesso(NumeroProcesso);
            Assert.NotNull(result);
            Assert.Equal(result.NumeroProcesso, NumeroProcesso);
        }
    }
}
