using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces;
using Api.Processos.Domain.Interfaces.Repositories;
using Api.Processos.Domain.Interfaces.Services;
using Api.Processos.Service.Validacoes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Processos.Service
{
    public class ProcessosService : IProcessosService
    {
        private IRepository<Processo> _repository;
        private IProcessosRepository _processosRepository;

        public ProcessosService(IRepository<Processo> repository, IProcessosRepository ProcessosRepository)
        {
            _repository = repository;
            _processosRepository = ProcessosRepository;
        }

        public async Task<ProcessoResultadoDto> AlterarStatusProcesso(StatusProcessoDto statusProcesso)
        {
            try
            {
                Processo processoSelecionado = await _processosRepository.BuscarPorNumeroProcesso(statusProcesso.NumeroProcesso);
                if (processoSelecionado is null)
                    return new ProcessoResultadoDto { msg = $"Processo {statusProcesso.NumeroProcesso} não localizado" };
                if (processoSelecionado.FlgAprovado)
                    return new ProcessoResultadoDto { msg = $"Processo {statusProcesso.NumeroProcesso} já foi comprado, você não pode alterar o status" };

                processoSelecionado.FlgAtivo = statusProcesso.Status;
                processoSelecionado.DataEdicao = DateTime.UtcNow;
                return new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = await _repository.UpdateAsync(processoSelecionado)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProcessoResultadoDto> AprovarCompra(CompraProcessoDto compraProcesso)
        {
            try
            {
                Processo processoSelecionado = await _processosRepository.BuscarPorNumeroProcesso(compraProcesso.NumeroProcesso);
                if (processoSelecionado is null)
                    return new ProcessoResultadoDto { msg = $"Processo {compraProcesso.NumeroProcesso} não localizado" };
                if (processoSelecionado.FlgAprovado)
                    return new ProcessoResultadoDto { msg = $"Processo {compraProcesso.NumeroProcesso} já foi comprado" };
                if (!processoSelecionado.FlgAtivo)
                    return new ProcessoResultadoDto { msg = $"Processo {compraProcesso.NumeroProcesso} inativo, você não pode realizar a compra" };
                if (!compraProcesso.StatusCompra)
                    return new ProcessoResultadoDto { msg = $"Processo {compraProcesso.NumeroProcesso} não foi comprado" };

                processoSelecionado.FlgAprovado = compraProcesso.StatusCompra;
                processoSelecionado.DataCompra = DateTime.UtcNow;

                return new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = await _repository.UpdateAsync(processoSelecionado)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProcessoResultadoDto> CriarProcesso(ProcessoDto processo)
        {
            try
            {
                processo.Escritorio = Regex.Replace(processo.Escritorio, @"[\d-]", string.Empty).Trim();
                processo.NomeReclamante = Regex.Replace(processo.NomeReclamante, @"[\d-]", string.Empty).Trim();

                var resultadoValidacoes = (ValidationResult)await Validacao(processo, true);

                if (!resultadoValidacoes.IsValid)
                {
                    return new ProcessoResultadoDto
                    {
                        msg = resultadoValidacoes.ToString(" | ")
                    };
                }


                Processo baseAprovacao = new Processo
                {
                    DataInclusao = DateTime.UtcNow,
                    Escritorio = processo.Escritorio,
                    FlgAprovado = false,
                    FlgAtivo = true,
                    NomeReclamante = processo.NomeReclamante,
                    NumeroProcesso = processo.NumeroProcesso,
                    ValorCausa = processo.ValorCausa
                };
                Processo resultado = await _repository.InsertAsync(baseAprovacao);
                return new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = resultado
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProcessoResultadoDto> EditarProcesso(ProcessoDto edicao)
        {
            try
            {
                Processo processoSelecionado = await _processosRepository.BuscarPorNumeroProcesso(edicao.NumeroProcesso);
                if (processoSelecionado is null)
                    return new ProcessoResultadoDto { msg = $"Processo {edicao.NumeroProcesso} não localizado" };
                if (processoSelecionado.FlgAprovado)
                    return new ProcessoResultadoDto { msg = $"Processo {edicao.NumeroProcesso} já foi comprado, não pode mais ser editado" };

                edicao.Escritorio = Regex.Replace(edicao.Escritorio, @"[\d-]", string.Empty).Trim();
                edicao.NomeReclamante = Regex.Replace(edicao.NomeReclamante, @"[\d-]", string.Empty).Trim();

                var resultadoValidacoes = (ValidationResult)await Validacao(edicao, false);

                if (!resultadoValidacoes.IsValid)
                {
                    return new ProcessoResultadoDto
                    {
                        processo = null,
                        msg = resultadoValidacoes.ToString(" | ")
                    };
                }

                processoSelecionado.DataEdicao = DateTime.UtcNow;
                processoSelecionado.Escritorio = edicao.Escritorio;
                processoSelecionado.NomeReclamante = edicao.NomeReclamante;
                processoSelecionado.ValorCausa = edicao.ValorCausa;

                return new ProcessoResultadoDto
                {
                    msg = "Sucesso",
                    processo = await _repository.UpdateAsync(processoSelecionado)
                };


            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Processo> ObterPorId(int id)
        {
            try
            {
                return await _repository.SelectAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Processo> ObterPorNumeroProcesso(string numeroProcesso)
        {
            try
            {
                return await _processosRepository.BuscarPorNumeroProcesso(numeroProcesso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Processo>> ObterTodosProcessos()
        {
            try
            {
                IEnumerable<Processo> processos = await _repository.SelectAsync();
                return processos.OrderByDescending(x => x.NumeroProcesso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> Validacao(ProcessoDto processo, bool validaNumeroProcessoExistente)
        {
            try
            {
                ProcessoValidacao validacoes = new ProcessoValidacao();
                var resultadoValidacoes = validacoes.Validate(processo);

                if (validaNumeroProcessoExistente && await _processosRepository.BuscarPorNumeroProcesso(processo.NumeroProcesso) != null)
                {
                    resultadoValidacoes.Errors.Add(new ValidationFailure("NumeroProcesso", $"Número do processo {processo.NumeroProcesso} já cadastrado"));
                }
                return resultadoValidacoes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
