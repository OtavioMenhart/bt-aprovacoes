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

namespace Api.Application.Teste.Processos.QuandoRequisitarObterPorNumeroProcesso
{
    public class RetornoBadRequest
    {
        private ProcessosController _controller;

        [Fact(DisplayName = "É possível Realizar o ObterPorNumeroProcesso.")]
        public async Task E_Possivel_Invocar_a_Controller_ObterPorNumeroProcesso()
        {
            var serviceMock = new Mock<IProcessosService>();
            string nomeReclamante = Faker.Name.FullName();
            string numeroProcesso = Faker.RandomNumber.Next().ToString();

            serviceMock.Setup(m => m.ObterPorNumeroProcesso(It.IsAny<string>())).ReturnsAsync(
                 new TblProcessos
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
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.ObterPorNumeroProcesso(Faker.RandomNumber.Next().ToString());
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
