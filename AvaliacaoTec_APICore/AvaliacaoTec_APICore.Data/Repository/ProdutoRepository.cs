using AvaliacaoTec_APICore.Data.Context;
using AvaliacaoTec_APICore.Data.Structure.Repository;
using AvaliacaoTec_APICore.Library.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoTec_APICore.Data.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(EntityContext context, IConfiguration configuration) => _context = context;

        public void Delete(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges();
        }

        public IEnumerable<Produto> GetAll()
        {
            var query = (from p in _context.Produto 
                         join c in _context.Categoria on p.idCategoria equals c.idCategoria into cat
                         from c in cat.DefaultIfEmpty()
                         select new Produto(p,c));

            return query;
        }

        public Produto GetById(int id)
        {
            var query = _context.Produto.FirstOrDefault(c => c.idProduto == id);

            return query;
        }

        public void Insert(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Update(produto);
            _context.SaveChanges();
        }
    }
}
