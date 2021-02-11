using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
