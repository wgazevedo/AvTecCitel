using AvaliacaoTec_APICore.Data.Structure.Repository;
using AvaliacaoTec_APICore.Library.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoTec_APICore.Business.Components
{
    public class ProdutoComponent
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public ProdutoComponent(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            this._produtoRepository = produtoRepository;
            this._categoriaRepository = categoriaRepository;
        }

        public void Insert(Produto produto)
        {
            _produtoRepository.Insert(produto);
        }
        public void Update(Produto produto)
        {
            _produtoRepository.Update(produto);
        }
        public void Delete(Produto produto)
        {
            _produtoRepository.Delete(produto);
        }
        public Produto GetById(int id)
        {
            var prod = _produtoRepository.GetById(id);
            prod.Categoria = _categoriaRepository.GetById(prod.idCategoria);

            return prod;
        }
        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }
    }
}
