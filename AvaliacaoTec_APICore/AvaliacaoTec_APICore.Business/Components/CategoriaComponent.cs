using AvaliacaoTec_APICore.Data.Structure.Repository;
using AvaliacaoTec_APICore.Library.Entities;
using System.Collections.Generic;

namespace AvaliacaoTec_APICore.Business.Components
{
    public class CategoriaComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaComponent(ICategoriaRepository categoriaRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }

        public void Insert(Categoria categoria)
        {
            _categoriaRepository.Insert(categoria);
        }
        public void Update(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
        }
        public void Delete(Categoria categoria)
        {
            _categoriaRepository.Delete(categoria);
        }
        public Categoria GetById(int id)
        {
           return _categoriaRepository.GetById(id);
        }
        public IEnumerable<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

    }
}
