using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoTec_APICore.Library.Entities
{
    public class Produto
    {
        public Produto()
        { }

        public Produto(Produto p, Categoria c)
        {
            idProduto = p.idProduto;
            idCategoria = p.idCategoria;
            Descricao = p.Descricao;
            Sigla = p.Sigla;
            Ativo = p.Ativo;
            SKU = p.SKU;
            Marca = p.Marca;
            Modelo = p.Modelo;
            Categoria = c;

        }

        [Key]
        public int idProduto { get; set; }
        public int idCategoria { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }
        public string SKU { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
