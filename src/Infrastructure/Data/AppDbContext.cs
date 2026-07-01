using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoqueAPI.Core.Entities;

namespace GerenciamentoEstoqueAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<HistoricoPreco> HistoricosPreco { get; set; } // 💡 Nova tabela

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(builder =>
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
                builder.Property(p => p.PrecoAtual).HasColumnType("decimal(18,2)");

                // 💡 Mapeia o relacionamento: 1 Produto para Muitos Históricos
                builder.HasMany(p => p.HistoricosPreco)
                       .WithOne()
                       .HasForeignKey(h => h.ProdutoId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<HistoricoPreco>(builder =>
            {
                builder.HasKey(h => h.Id);
                builder.Property(h => h.PrecoAntigo).HasColumnType("decimal(18,2)");
                builder.Property(h => h.PrecoNovo).HasColumnType("decimal(18,2)");
            });
        }
    }
}