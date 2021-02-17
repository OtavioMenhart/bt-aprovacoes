using Api.Processos.Controllers;
using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Teste.Processos.QuandoRequisitarEditarProcesso
{
    public class RetornoBadRequest
    {
        private ProcessoController _controller;

        [Fact(DisplayName = "É possível testar badrequest EditarProcesso.")]
        public async Task E_Possivel_Invocar_a_Controller_EditarProcesso()
        {
            var serviceMock = new Mock<IProcessoService>();
            var nomeReclamente = Faker.Name.FullName();
            var escritorio = Faker.Company.Name();
            var numeroProcesso = Faker.RandomNumber.Next().ToString();

            serviceMock.Setup(m => m.EditarProcesso(It.IsAny<ProcessoDto>())).ReturnsAsync(
                new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = new ProcessoRetornoDto
                    {
                        DataInclusao = DateTime.UtcNow,
                        Escritorio = escritorio,
                        FlgAprovado = false,
                        FlgAtivo = true,
                        NomeReclamante = nomeReclamente,
                        NumeroProcesso = "",
                        ValorCausa = Faker.RandomNumber.Next()
                    }
                }
            );

            _controller = new ProcessoController(serviceMock.Object);
            _controller.ModelState.AddModelError("NumeroProcesso", "NumeroProcesso é obrigatório");

            var processoDtoUpdate = new ProcessoDto
            {
                NumeroProcesso = "",
                Escritorio = Faker.Company.Name(),
                NomeReclamante = nomeReclamente,
                ValorCausa = Faker.RandomNumber.Next()
            };

            var result = await _controller.EditarProcesso(processoDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
