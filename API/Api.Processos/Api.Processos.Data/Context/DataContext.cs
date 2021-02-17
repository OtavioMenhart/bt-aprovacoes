using Api.Processos.Domain;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfiguracaoBD.conexaoBd);
            }
        }

        public virtual DbSet<Processo> TblProcessos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>(entity =>
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
