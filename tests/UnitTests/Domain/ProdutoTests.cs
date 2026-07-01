using GerenciamentoEstoqueAPI.Core.Entities;
using GerenciamentoEstoqueAPI.Core.Exceptions;
using Xunit;

namespace GerenciamentoEstoqueAPI.Tests.UnitTests.Domain
{
    public class ProdutoTests
    {
        [Fact]
        public void DebitarEstoque_DeveReduzirQuantidade_QuandoEstoqueSuficiente()
        {
            // Arrange
            var produto = new Produto("Placa de Vídeo RTX 4060", 10, 2, 250000m);

            // Act
            produto.DebitarEstoque(4);

            // Assert
            Assert.Equal(6, produto.QuantidadeEstoque);
        }

        [Fact]
        public void DebitarEstoque_DeveLancarBusinessException_QuandoEstoqueInsuficiente()
        {
            // Arrange
            var produto = new Produto("Memória RAM 16GB", 3, 1, 35000m);

            // Act & Assert
            var excecao = Assert.Throws<BusinessException>(() => produto.DebitarEstoque(5));
            Assert.Equal("Estoque insuficiente para esta operação.", excecao.Message);
        }

        [Fact]
        public void TemEstoqueBaixo_DeveRetornarVerdadeiro_QuandoAtingirOuSubstituirEstoqueMinimo()
        {
            // Arrange
            var produto = new Produto("SSD 1TB", 5, 2, 40000m);

            // Act
            produto.DebitarEstoque(3); // Estoque vai para 2 (igual ao mínimo)

            // Assert
            Assert.True(produto.TemEstoqueBaixo());
        }
    }
}