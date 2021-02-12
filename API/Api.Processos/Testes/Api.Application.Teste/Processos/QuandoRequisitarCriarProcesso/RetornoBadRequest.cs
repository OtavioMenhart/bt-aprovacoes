using Api.Processos.Controllers;
using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Teste.Processos.QuandoRequisitarCriarProcesso
{
    public class RetornoBadRequest
    {
        private ProcessosController _controller;
        [Fact(DisplayName = "Foi possível testar bad request.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IProcessosService>();

            serviceMock.Setup(x => x.CriarProcesso(It.IsAny<ProcessoDto>())).ReturnsAsync(new ProcessoResultadoDto
            {
                msg = "Sucesso",
                processo = new TblProcessos
                {
                    Id = Faker.RandomNumber.Next(),
                    DataInclusao = DateTime.UtcNow,
                    Escritorio = Faker.Company.Name(),
                    FlgAprovado = false,
                    FlgAtivo = true,
                    NomeReclamante = Faker.Name.FullName(),
                    NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                    ValorCausa = Faker.RandomNumber.Next()
                }
            });

            _controller = new ProcessosController(serviceMock.Object);
            _controller.ModelState.AddModelError("NumeroProcesso", "É um Campo Obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var processoDtoCreate = new ProcessoDto
            {
                Escritorio = Faker.Company.Name(),
                NomeReclamante = Faker.Name.FullName(),
                NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                ValorCausa = Faker.RandomNumber.Next()
            };

            var result = await _controller.CriarProcesso(processoDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
