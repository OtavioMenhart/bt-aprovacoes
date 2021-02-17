using Api.Processos.Domain.Entities;

namespace Api.Processos.Domain.Dtos
{
    public class ProcessoResultadoDto
    {
        public Processo processo { get; set; }
        public string msg { get; set; }
    }
}
