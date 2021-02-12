using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoObterPorId : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível obter processo por id")]
        public async Task E_Possivel_Obter_Processo_Por_Id()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.ObterPorId(Id)).ReturnsAsync(tblProcessos);
            _service = _serviceMock.Object;

            var result = await _service.ObterPorId(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
        }
    }
}
