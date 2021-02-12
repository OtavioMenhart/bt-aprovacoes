using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Processos.Domain.Interfaces.Services
{
    public interface IProcessosService
    {
        Task<ProcessoResultadoDto> CriarProcesso(ProcessoDto aprovacao);
        Task<TblProcessos> ObterPorId(int id);
        Task<ProcessoResultadoDto> EditarProcesso(ProcessoDto edicao);
        Task<object> Validacao(ProcessoDto processo, bool validaNumeroProcessoExistente);
        Task<ProcessoResultadoDto> AlterarStatusProcesso(StatusProcessoDto statusProcesso);
        Task<IEnumerable<TblProcessos>> ObterTodosProcessos();
        Task<ProcessoResultadoDto> AprovarCompra(CompraProcessoDto compraProcesso);
        Task<TblProcessos> ObterPorNumeroProcesso(string numeroProcesso);
    }
}
