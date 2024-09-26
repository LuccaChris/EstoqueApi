using System;

namespace EstoqueApi.Models  // Ajuste o namespace para o nome do seu projeto
{ 
public class Fornecedor
    {
        public int IdEstoque { get; set; }

        // relacionamento com o produto
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public int NivelMinimo { get; set; }
        public DateTime DataAtualizacao { get; set; }


}