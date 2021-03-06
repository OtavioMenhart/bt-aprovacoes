﻿using Api.Processos.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Api.Service.Teste.Processos
{
    public class BaseProcessosTestes
    {
        public static int Id { get; set; }
        public static string NumeroProcesso { get; set; }
        public static decimal ValorCausa { get; set; }
        public static string Escritorio { get; set; }
        public static string NomeReclamante { get; set; }

        public ProcessoDto processoDtoCreate;
        public ProcessoDto processoDtoUpdate;
        public ProcessoResultadoDto resultadoDtoSucessoUpdate;
        public ProcessoResultadoDto resultadoDtoSucesso;
        public ProcessoResultadoDto resultadoDtoFalha;
        public ProcessoRetornoDto tblProcessos;
        public List<ProcessoRetornoDto> listaProcessos = new List<ProcessoRetornoDto>();
        public CompraProcessoDto compraProcesso;
        public ProcessoResultadoDto resultadoCompraDto;
        public StatusProcessoDto statusProcesso;
        public ProcessoResultadoDto resultadoStatusDto;

        public BaseProcessosTestes()
        {
            Id = Faker.RandomNumber.Next();
            NumeroProcesso = Faker.RandomNumber.Next().ToString();
            ValorCausa = Faker.RandomNumber.Next();
            NomeReclamante = Faker.Name.FullName();
            Escritorio = Faker.Company.Name();

            for (int i = 0; i < 10; i++)
            {
                listaProcessos.Add(new ProcessoRetornoDto
                {
                    Escritorio = Faker.Company.Name(),
                    NomeReclamante = Faker.Name.FullName(),
                    NumeroProcesso = Faker.RandomNumber.Next().ToString(),
                    ValorCausa = Faker.RandomNumber.Next(),
                    DataInclusao = DateTime.UtcNow,
                    FlgAtivo = true
                });
            }

            processoDtoCreate = new ProcessoDto
            {
                Escritorio = Escritorio,
                NomeReclamante = NomeReclamante,
                NumeroProcesso = NumeroProcesso,
                ValorCausa = ValorCausa
            };

            processoDtoUpdate = new ProcessoDto
            {
                Escritorio = Faker.Company.Name(),
                NomeReclamante = Faker.Name.FullName(),
                NumeroProcesso = NumeroProcesso,
                ValorCausa = Faker.RandomNumber.Next()
            };
            resultadoDtoSucessoUpdate = new ProcessoResultadoDto
            {
                msg = "Sucesso",
                processo = new ProcessoRetornoDto
                {
                    Escritorio = processoDtoUpdate.Escritorio,
                    NomeReclamante = processoDtoUpdate.NomeReclamante,
                    NumeroProcesso = processoDtoUpdate.NumeroProcesso,
                    ValorCausa = processoDtoUpdate.ValorCausa,
                    DataInclusao = DateTime.UtcNow,
                    FlgAtivo = true
                }
            };

            tblProcessos = new ProcessoRetornoDto
            {
                DataInclusao = DateTime.UtcNow,
                Escritorio = Escritorio,
                FlgAprovado = false,
                FlgAtivo = true,
                NomeReclamante = NomeReclamante,
                NumeroProcesso = NumeroProcesso,
                ValorCausa = ValorCausa
            };

            resultadoDtoSucesso = new ProcessoResultadoDto
            {
                msg = "Sucesso",
                processo = tblProcessos
            };

            resultadoDtoFalha = new ProcessoResultadoDto { msg = "Número do processo é um campo obrigatório" };

            compraProcesso = new CompraProcessoDto
            {
                NumeroProcesso = NumeroProcesso,
                StatusCompra = true
            };
            resultadoCompraDto = new ProcessoResultadoDto
            {
                msg = "Sucesso",
                processo = new ProcessoRetornoDto
                {
                    DataInclusao = DateTime.UtcNow,
                    Escritorio = Escritorio,
                    FlgAprovado = true,
                    FlgAtivo = true,
                    NomeReclamante = NomeReclamante,
                    NumeroProcesso = NumeroProcesso,
                    ValorCausa = ValorCausa,
                    DataCompra = DateTime.UtcNow
                }
            };

            statusProcesso = new StatusProcessoDto
            {
                NumeroProcesso = NumeroProcesso,
                Status = true
            };

            resultadoStatusDto = new ProcessoResultadoDto
            {
                msg = "Sucesso",
                processo = new ProcessoRetornoDto
                {
                    DataInclusao = DateTime.UtcNow,
                    Escritorio = Escritorio,
                    FlgAprovado = true,
                    FlgAtivo = true,
                    NomeReclamante = NomeReclamante,
                    NumeroProcesso = NumeroProcesso,
                    ValorCausa = ValorCausa,
                    DataCompra = DateTime.UtcNow
                }
            };

        }
    }
}
