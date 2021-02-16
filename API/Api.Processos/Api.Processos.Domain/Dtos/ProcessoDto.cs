using System.ComponentModel.DataAnnotations;

namespace Api.Processos.Domain.Dtos
{
    public class ProcessoDto
    {
        [Required]
        public string NumeroProcesso { get; set; }
        [Required]
        public decimal ValorCausa { get; set; }
        [Required]
        public string Escritorio { get; set; }
        [Required]
        public string NomeReclamante { get; set; }
    }
}
