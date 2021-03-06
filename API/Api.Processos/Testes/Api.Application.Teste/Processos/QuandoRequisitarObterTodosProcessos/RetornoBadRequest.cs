﻿using Api.Processos.Controllers;
using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Teste.Processos.QuandoRequisitarObterTodosProcessos
{
    public class RetornoBadRequest
    {
        private ProcessoController _controller;

        [Fact(DisplayName = "É possível Realizar o ObterTodos.")]
        public async Task E_Possivel_Invocar_a_Controller_ObterTodos()
        {
            var serviceMock = new Mock<IProcessoService>();
            serviceMock.Setup(m => m.ObterTodosProcessos()).ReturnsAsync(
                 new List<ProcessoRetornoDto>
                 {
                    new ProcessoRetornoDto
                    {
                        DataInclusao = DateTime.UtcNow,
                        Escritorio = Faker.Company.Name(),
                        FlgAprovado = false,
                        FlgAtivo = true,
                        NomeReclamante = Faker.Name.FullName(),
                        NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                        ValorCausa = Faker.RandomNumber.Next()
                    },
                    new ProcessoRetornoDto
                    {
                        DataInclusao = DateTime.UtcNow,
                        Escritorio = Faker.Company.Name(),
                        FlgAprovado = false,
                        FlgAtivo = true,
                        NomeReclamante = Faker.Name.FullName(),
                        NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                        ValorCausa = Faker.RandomNumber.Next()
                    }
                 }
            );
            _controller = new ProcessoController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.ObterTodosProcessos();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
