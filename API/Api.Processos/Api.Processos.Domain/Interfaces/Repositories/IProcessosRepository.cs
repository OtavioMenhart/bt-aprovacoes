using Api.Processos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Processos.Domain.Interfaces.Repositories
{
    public interface IProcessosRepository : IRepository<TblProcessos>
    {
        Task<TblProcessos> BuscarPorNumeroProcesso(string numeroProcesso);
    }
}
