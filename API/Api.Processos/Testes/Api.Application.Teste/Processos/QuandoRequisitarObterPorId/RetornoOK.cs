using Api.Processos.Controllers;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Teste.Processos.QuandoRequisitarObterPorId
{
    public class RetornoOK
    {
        private ProcessosController _controller;

        [Fact(DisplayName = "É possível Realizar o ObterPorId.")]
        public async Task E_Possivel_Invocar_a_Controller_ObterPorId()
        {
            string nomeReclamante = Faker.Name.FullName();
            string numeroProcesso = Faker.RandomNumber.Next().ToString();
            var serviceMock = new Mock<IProcessosService>();

            serviceMock.Setup(m => m.ObterPorId(It.IsAny<int>())).ReturnsAsync(
                 new Processo
                 {
                     Id = Faker.RandomNumber.Next(),
                     DataInclusao = DateTime.UtcNow,
                     Escritorio = Faker.Company.Name(),
                     FlgAprovado = false,
                     FlgAtivo = true,
                     NomeReclamante = nomeReclamante,
                     NumeroProcesso = numeroProcesso,
                     ValorCausa = Faker.RandomNumber.Next()
                 }
            );

            _controller = new ProcessosController(serviceMock.Object);
            var result = await _controller.ObterPorId(Faker.RandomNumber.Next());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as Processo;
            Assert.NotNull(resultValue);
            Assert.Equal(nomeReclamante, resultValue.NomeReclamante);
            Assert.Equal(numeroProcesso, resultValue.NumeroProcesso);

        }
    }
}
