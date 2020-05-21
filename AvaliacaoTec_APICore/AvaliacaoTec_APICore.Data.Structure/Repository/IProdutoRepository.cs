using AvaliacaoTec_APICore.Library.Entities;
using System.Collections.Generic;

namespace AvaliacaoTec_APICore.Data.Structure.Repository
{
    public interface IProdutoRepository
    {
        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        Produto GetById(int id);
        IEnumerable<Produto> GetAll();
    }
}
