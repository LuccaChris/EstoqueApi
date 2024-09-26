using System;


namespace EstoqueApi.Models  // Ajuste o namespace para o nome do seu projeto
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        // Relacionamento com Fornecedor
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}