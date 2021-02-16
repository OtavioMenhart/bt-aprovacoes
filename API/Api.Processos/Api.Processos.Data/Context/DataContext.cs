using Api.Processos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Processos.Data.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblProcessos> TblProcessos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProcessos>(entity =>
            {
                entity.HasIndex(e => e.NumeroProcesso)
                    .HasName("UC_NumeroProcesso")
                    .IsUnique();

                entity.Property(e => e.Escritorio).IsUnicode(false);

                entity.Property(e => e.NomeReclamante).IsUnicode(false);

                entity.Property(e => e.NumeroProcesso).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
