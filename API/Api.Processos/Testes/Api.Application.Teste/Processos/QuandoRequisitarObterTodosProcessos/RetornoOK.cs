﻿using Api.Processos.Controllers;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Teste.Processos.QuandoRequisitarObterTodosProcessos
{
    public class RetornoOK
    {
        private ProcessosController _controller;

        [Fact(DisplayName = "É possível realizar obter todos.")]
        public async Task E_Possivel_Invocar_a_Controller_ObterTodos()
        {
            var serviceMock = new Mock<IProcessosService>();
            serviceMock.Setup(m => m.ObterTodosProcessos()).ReturnsAsync(
                 new List<Processo>
                 {
                    new Processo
                    {
                        Id = Faker.RandomNumber.Next(),
                        DataInclusao = DateTime.UtcNow,
                        Escritorio = Faker.Company.Name(),
                        FlgAprovado = false,
                        FlgAtivo = true,
                        NomeReclamante = Faker.Name.FullName(),
                        NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                        ValorCausa = Faker.RandomNumber.Next()
                    },
                    new Processo
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
                 }
            );
            _controller = new ProcessosController(serviceMock.Object);
            var result = await _controller.ObterTodosProcessos();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<Processo>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
