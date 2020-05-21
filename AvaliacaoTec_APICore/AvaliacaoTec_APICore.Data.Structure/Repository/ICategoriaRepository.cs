using AvaliacaoTec_APICore.Library.Entities;
using System.Collections.Generic;

namespace AvaliacaoTec_APICore.Data.Structure.Repository
{
    public interface ICategoriaRepository
    {
        void Insert(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        Categoria GetById(int id);
        IEnumerable<Categoria> GetAll();
    }
}
