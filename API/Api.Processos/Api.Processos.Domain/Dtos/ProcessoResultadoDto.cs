using Api.Processos.Domain.Entities;

namespace Api.Processos.Domain.Dtos
{
    public class ProcessoResultadoDto
    {
        public TblProcessos processo { get; set; }
        public string msg { get; set; }
    }
}
