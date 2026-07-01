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
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}