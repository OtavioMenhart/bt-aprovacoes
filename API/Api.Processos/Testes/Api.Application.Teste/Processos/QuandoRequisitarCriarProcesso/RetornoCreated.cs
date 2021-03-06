﻿using Api.Processos.Controllers;
using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Teste.Processos.QuandoRequisitarCriarProcesso
{
    public class RetornoCreated
    {
        private ProcessoController _controller;

        [Fact(DisplayName = "É possível criar processo")]
        public async Task E_Possivel_Criar_Processo()
        {
            var serviceMock = new Mock<IProcessoService>();


            serviceMock.Setup(x => x.CriarProcesso(It.IsAny<ProcessoDto>())).ReturnsAsync(new ProcessoResultadoDto
            {
                msg = "Sucesso",
                processo = new ProcessoRetornoDto
                {
                    DataInclusao = DateTime.UtcNow,
                    Escritorio = Faker.Company.Name(),
                    FlgAprovado = false,
                    FlgAtivo = true,
                    NomeReclamante = Faker.Name.FullName(),
                    NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                    ValorCausa = Faker.RandomNumber.Next()
                }
            });

            _controller = new ProcessoController(serviceMock.Object);

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
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as ProcessoResultadoDto;
            Assert.NotNull(resultValue);
        }

    }
}
