using System;

namespace GerenciamentoEstoqueAPI.Core.Entities
{
    public class HistoricoPreco
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal PrecoAntigo { get; private set; }
        public decimal PrecoNovo { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        // Construtor privado para o EF Core
        private HistoricoPreco() { }

        public HistoricoPreco(Guid produtoId, decimal precoAntigo, decimal precoNovo)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            PrecoAntigo = precoAntigo;
            PrecoNovo = precoNovo;
            DataAlteracao = DateTime.UtcNow;
        }
    }
}