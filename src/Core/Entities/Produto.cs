using GerenciamentoEstoqueAPI.Core.Exceptions;

namespace GerenciamentoEstoqueAPI.Core.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public int EstoqueMinimo { get; private set; }
        public decimal PrecoAtual { get; private set; }

        private Produto() { }

        public Produto(string nome, int estoqueInicial, int estoqueMinimo, decimal precoInicial)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new BusinessException("O nome do produto é obrigatório.");
            if (estoqueInicial < 0) throw new BusinessException("O estoque inicial não pode ser negativo.");
            if (estoqueMinimo < 0) throw new BusinessException("O estoque mínimo não pode ser negativo.");
            if (precoInicial <= 0) throw new BusinessException("O preço inicial deve ser maior que zero.");

            Id = Guid.NewGuid();
            Nome = nome;
            QuantidadeEstoque = estoqueInicial;
            EstoqueMinimo = estoqueMinimo;
            PrecoAtual = precoInicial;
        }

        // Método para debitar estoque
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade <= 0) throw new BusinessException("A quantidade a debitar deve ser maior que zero.");
            if (QuantidadeEstoque - quantidade < 0) throw new BusinessException("Estoque insuficiente para esta operação.");

            QuantidadeEstoque -= quantidade;
        }

        // Método verificar se precisa de alerta
        public bool TemEstoqueBaixo()
        {
            return QuantidadeEstoque <= EstoqueMinimo;
        }

        // Método atualizar preço
        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0) throw new BusinessException("O novo preço deve ser maior que zero.");
            PrecoAtual = novoPreco;
        }
    }
}