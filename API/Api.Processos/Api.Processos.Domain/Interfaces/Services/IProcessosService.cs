using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Processos.Domain.Interfaces.Services
{
    public interface IProcessosService
    {
        Task<ProcessoResultadoDto> CriarProcesso(ProcessoDto aprovacao);
        Task<Processo> ObterPorId(int id);
        Task<ProcessoResultadoDto> EditarProcesso(ProcessoDto edicao);
        Task<object> Validacao(ProcessoDto processo, bool validaNumeroProcessoExistente);
        Task<ProcessoResultadoDto> AlterarStatusProcesso(StatusProcessoDto statusProcesso);
        Task<IEnumerable<Processo>> ObterTodosProcessos();
        Task<ProcessoResultadoDto> AprovarCompra(CompraProcessoDto compraProcesso);
        Task<Processo> ObterPorNumeroProcesso(string numeroProcesso);
    }
}
