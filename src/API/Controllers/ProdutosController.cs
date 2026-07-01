using Microsoft.AspNetCore.Mvc;
using GerenciamentoEstoqueAPI.Application.Services;
using GerenciamentoEstoqueAPI.Application.DTOs;
using GerenciamentoEstoqueAPI.Core.Entities;
using GerenciamentoEstoqueAPI.Core.Interfaces;

namespace GerenciamentoEstoqueAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly EstoqueServico _estoqueServico;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutosController(EstoqueServico estoqueServico, IProdutoRepositorio produtoRepositorio)
        {
            _estoqueServico = estoqueServico;
            _produtoRepositorio = produtoRepositorio;
        }

        // Simular crianção de ID
        [HttpPost]
        public async Task<IActionResult> CriarProduto(string nome, int estoque, int minimo, decimal preco)
        {
            var produto = new Produto(nome, estoque, minimo, preco);
            await _produtoRepositorio.AdicionarAsync(produto);
            return Ok(new { Id = produto.Id, Mensagem = "Produto criado para testes!" });
        }

        // Endpoint baixa de estoque
        [HttpPost("{id}/baixar-estoque")]
        public async Task<IActionResult> BaixarEstoque(Guid id, [FromBody] BaixarEstoqueInput input)
        {
            // O Middleware global vai capturar se estourar alguma BusinessException
            await _estoqueServico.BaixarEstoqueAsync(id, input.Quantidade);
            return Ok(new { Mensagem = "Baixa de estoque realizada com sucesso!" });
        }
    }
}