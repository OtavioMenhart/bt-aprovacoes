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

namespace Api.Application.Teste.Processos.QuandoRequisitarAprovarCompra
{
    public class RetornoBadRequest
    {
        private ProcessosController _controller;

        [Fact(DisplayName = "É possível testar badrequest AprovarCompra.")]
        public async Task E_Possivel_Invocar_a_Controller_AprovarCompra()
        {
            var serviceMock = new Mock<IProcessosService>();
            var nomeReclamente = Faker.Name.FullName();
            var escritorio = Faker.Company.Name();
            var numeroProcesso = Faker.RandomNumber.Next().ToString();

            serviceMock.Setup(m => m.AprovarCompra(It.IsAny<CompraProcessoDto>())).ReturnsAsync(
                new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = new Processo
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

            var processoDtoUpdate = new CompraProcessoDto
            {
                NumeroProcesso = "",
                StatusCompra = true
            };

            var result = await _controller.AprovarCompra(processoDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
