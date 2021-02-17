using Api.Processos.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Processos.Domain.Interfaces.Services
{
    public interface IProcessoService
    {
        Task<ProcessoResultadoDto> CriarProcesso(ProcessoDto aprovacao);
        Task<ProcessoResultadoDto> EditarProcesso(ProcessoDto edicao);
        Task<object> Validacao(ProcessoDto processo, bool validaNumeroProcessoExistente);
        Task<ProcessoResultadoDto> AlterarStatusProcesso(StatusProcessoDto statusProcesso);
        Task<IEnumerable<ProcessoRetornoDto>> ObterTodosProcessos();
        Task<ProcessoResultadoDto> AprovarCompra(CompraProcessoDto compraProcesso);
        Task<ProcessoRetornoDto> ObterPorNumeroProcesso(string numeroProcesso);
    }
}
