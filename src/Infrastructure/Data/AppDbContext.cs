using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoqueAPI.Core.Entities;

namespace GerenciamentoEstoqueAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do mapeamento
            modelBuilder.Entity<Produto>(builder =>
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
                builder.Property(p => p.PrecoAtual).HasColumnType("decimal(18,2)");
            });
        }
    }
}