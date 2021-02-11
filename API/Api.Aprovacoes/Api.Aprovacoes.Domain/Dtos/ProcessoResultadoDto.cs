using Api.Processos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Processos.Domain.Dtos
{
    public class ProcessoResultadoDto
    {
        public TblProcessos processo { get; set; }
        public string msg { get; set; }
    }
}
