using System;
using System.Threading.Tasks;
using GerenciamentoEstoqueAPI.Core.Entities;

namespace GerenciamentoEstoqueAPI.Core.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
    }
}