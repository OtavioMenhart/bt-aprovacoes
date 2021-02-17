using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Processos.Domain.Dtos
{
    public class ProcessoRetornoDto
    {
        public string NumeroProcesso { get; set; }
        public decimal ValorCausa { get; set; }
        public string Escritorio { get; set; }
        public string NomeReclamante { get; set; }
        public DateTime DataInclusao { get; set; }
        public bool FlgAtivo { get; set; }
        public bool FlgAprovado { get; set; }
        public DateTime? DataCompra { get; set; }
    }
}
