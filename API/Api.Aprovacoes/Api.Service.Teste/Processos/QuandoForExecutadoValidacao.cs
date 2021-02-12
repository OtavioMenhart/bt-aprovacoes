using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoValidacao : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível validar processo")]
        public async Task E_Possivel_Validar_Processo()
        {
            processoDtoCreate.NumeroProcesso = null;
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.Validacao(processoDtoCreate, false)).ReturnsAsync(resultadoDtoFalha);
            _service = _serviceMock.Object;

            var result = await _service.Validacao(processoDtoCreate, false);
            Assert.NotNull(result);
        }
    }
}
