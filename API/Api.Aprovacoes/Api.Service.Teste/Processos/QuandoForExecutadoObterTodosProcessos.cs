using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoObterTodosProcessos : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível obter todos os processos")]
        public async Task E_Possivel_Obter_Todos_Processos()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.ObterTodosProcessos()).ReturnsAsync(listaProcessos);
            _service = _serviceMock.Object;

            var result = await _service.ObterTodosProcessos();
            Assert.NotNull(result);
            Assert.True(result.Count() == listaProcessos.Count);
        }
    }
}
