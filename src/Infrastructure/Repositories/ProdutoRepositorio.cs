using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoqueAPI.Core.Entities;
using GerenciamentoEstoqueAPI.Core.Interfaces;
using GerenciamentoEstoqueAPI.Infrastructure.Data;

namespace GerenciamentoEstoqueAPI.Infrastructure.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _context;

        public ProdutoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await _context.Produtos
           .Include(p => p.HistoricosPreco)
           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            foreach (var historico in produto.HistoricosPreco)
            {
                var existeNoRastreador = _context.HistoricosPreco.Any(h => h.Id == historico.Id);
                if (!existeNoRastreador)
                {
                    await _context.HistoricosPreco.AddAsync(historico);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}