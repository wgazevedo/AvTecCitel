using AvaliacaoTec_APICore.Data.Context;
using AvaliacaoTec_APICore.Data.Structure.Repository;
using AvaliacaoTec_APICore.Library.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoTec_APICore.Data.Repository
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public CategoriaRepository(EntityContext context, IConfiguration configuration) => _context = context;

        public void Delete(Categoria categoria)
        {
            _context.Remove(categoria);
            _context.SaveChanges();
        }

        public IEnumerable<Categoria> GetAll()
        {
            var query = (from c in _context.Categoria select c);

            return query;
        }

        public Categoria GetById(int id)
        {
            var query = _context.Categoria.FirstOrDefault(c => c.idCategoria == id);

            return query;
        }

        public void Insert(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Update(categoria);
            _context.SaveChanges();
        }
    }
}
