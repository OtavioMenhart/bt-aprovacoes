using Api.Processos.Data.Context;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Processos.Data.Repositories
{
    public class ProcessosRepository : BaseRepository<TblProcessos>, IProcessosRepository
    {
        private DbSet<TblProcessos> _dataSet;
        public ProcessosRepository(DataContext context) : base(context)
        {
            _dataSet = context.Set<TblProcessos>();
        }

        public async Task<TblProcessos> BuscarPorNumeroProcesso(string numeroProcesso)
        {
            try
            {
                return await _dataSet.FirstOrDefaultAsync(x => x.NumeroProcesso == numeroProcesso);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
