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

namespace Api.Application.Teste.Processos.QuandoRequisitarAlterarStatusProcesso
{
    public class RetornoBadRequest
    {
        private ProcessosController _controller;

        [Fact(DisplayName = "É possível testar badrequest AlterarStatusProcesso.")]
        public async Task E_Possivel_Invocar_a_Controller_AlterarStatusProcesso()
        {
            var serviceMock = new Mock<IProcessosService>();
            var nomeReclamente = Faker.Name.FullName();
            var escritorio = Faker.Company.Name();
            var numeroProcesso = Faker.RandomNumber.Next().ToString();

            serviceMock.Setup(m => m.AlterarStatusProcesso(It.IsAny<StatusProcessoDto>())).ReturnsAsync(
                new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = new TblProcessos
                    {
                        Id = Faker.RandomNumber.Next(),
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

            _controller = new ProcessosController(serviceMock.Object);
            _controller.ModelState.AddModelError("NumeroProcesso", "NumeroProcesso é obrigatório");

            var processoDtoUpdate = new StatusProcessoDto
            {
                NumeroProcesso = "",
                Status = true
            };

            var result = await _controller.AlterarStatusProcesso(processoDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
