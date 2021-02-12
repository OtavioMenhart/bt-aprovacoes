using Api.Processos.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Teste.Processos
{
    public class QuandoForExecutadoAprovarCompra : BaseProcessosTestes
    {
        private IProcessosService _service;
        private Mock<IProcessosService> _serviceMock;

        [Fact(DisplayName = "É possível aprovar compra do processo")]
        public async Task E_Possivel_Aprovar_Compra_Processo()
        {
            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.CriarProcesso(processoDtoCreate)).ReturnsAsync(resultadoDtoSucesso);
            _service = _serviceMock.Object;

            var result = await _service.CriarProcesso(processoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(processoDtoCreate.NomeReclamante, result.processo.NomeReclamante);
            Assert.Equal(processoDtoCreate.NumeroProcesso, result.processo.NumeroProcesso);

            _serviceMock = new Mock<IProcessosService>();
            _serviceMock.Setup(x => x.AprovarCompra(compraProcesso)).ReturnsAsync(resultadoCompraDto);
            _service = _serviceMock.Object;

            var resultCompra = await _service.AprovarCompra(compraProcesso);
            Assert.NotNull(resultCompra);
            Assert.Equal(resultadoCompraDto.processo.NomeReclamante, resultCompra.processo.NomeReclamante);
            Assert.Equal(resultadoCompraDto.processo.NumeroProcesso, resultCompra.processo.NumeroProcesso);
            Assert.True(resultadoCompraDto.processo.FlgAprovado);
            Assert.True(resultCompra.processo.FlgAprovado);
        }

    }
}
