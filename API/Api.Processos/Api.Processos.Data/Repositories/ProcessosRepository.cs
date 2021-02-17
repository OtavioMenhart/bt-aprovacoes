using Api.Processos.Data.Context;
using Api.Processos.Domain.Entities;
using Api.Processos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Api.Processos.Data.Repositories
{
    public class ProcessosRepository : BaseRepository<Processo>, IProcessosRepository
    {
        private DbSet<Processo> _dataSet;
        public ProcessosRepository(DataContext context) : base(context)
        {
            _dataSet = context.Set<Processo>();
        }

        public async Task<Processo> BuscarPorNumeroProcesso(string numeroProcesso)
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
