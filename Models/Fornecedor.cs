using System.Collections.Generic;  // Necessário para ICollection

namespace EstoqueApi.Models  // Ajuste o namespace para o nome do seu projeto
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }

        // Relacionamento com Produto
        public ICollection<Produto> Produtos { get; set; }
    }
}