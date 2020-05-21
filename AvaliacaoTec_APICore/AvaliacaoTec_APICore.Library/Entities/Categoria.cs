using System.ComponentModel.DataAnnotations;

namespace AvaliacaoTec_APICore.Library.Entities
{
    public class Categoria
    {
        public Categoria()
        {
        }

        [Key]
        public int idCategoria { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }

    }
}
