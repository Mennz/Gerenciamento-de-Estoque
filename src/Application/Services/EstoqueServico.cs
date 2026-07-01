using GerenciamentoEstoqueAPI.Core.Exceptions;
using GerenciamentoEstoqueAPI.Core.Entities;
using GerenciamentoEstoqueAPI.Core.Interfaces;

namespace GerenciamentoEstoqueAPI.Application.Services
{
    public class EstoqueServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IAlertaServico _alertaServico;

        public EstoqueServico(IProdutoRepositorio produtoRepositorio, IAlertaServico alertaServico)
        {
            _produtoRepositorio = produtoRepositorio;
            _alertaServico = alertaServico;
        }

        public async Task BaixarEstoqueAsync(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepositorio.ObterPorIdAsync(produtoId);
            if (produto == null) throw new NotFoundException("Produto não encontrado.");

            // Executa a lógica encapsulada na entidade
            produto.DebitarEstoque(quantidade);

            // Verifica a regra de alerta
            if (produto.TemEstoqueBaixo())
            {
                _alertaServico.DispararAlertaEstoqueBaixo(produto.Nome, produto.QuantidadeEstoque);
            }

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}