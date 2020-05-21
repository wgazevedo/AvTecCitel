using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoTec_APICore.Business.Components;
using AvaliacaoTec_APICore.Library.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoTec_APICore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaComponent _categoriaComponent;

        public CategoriaController(CategoriaComponent categoriaComponent)
        {
            _categoriaComponent = categoriaComponent;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            ActionResult response;

            try
            {                
                var categoria = _categoriaComponent.GetAll();

                response = Ok(categoria);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex);
            }

            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            ActionResult response;

            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException("Id is required");
                }

                var categoria = _categoriaComponent.GetById(id);

                if (categoria == null || categoria.idCategoria == 0)
                    return NotFound();

                response = Ok(categoria);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex);
            }

            return response;
        }

        [HttpPost]
        public void Post(Categoria categoria)
        {
            try
            {
                _categoriaComponent.Insert(categoria);

                Ok();
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }

        [HttpPut]
        public void Put(Categoria categoria)
        {
            if (categoria.idCategoria == 0)
            {
                throw new ArgumentNullException("IdCategoria is required");
            }

            try
            {
                _categoriaComponent.Update(categoria);

                Ok();
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ActionResult response;

            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException("Id is required");
                }

                var categoria = _categoriaComponent.GetById(id);

                if (categoria == null || categoria.idCategoria == 0)
                {
                    throw new ArgumentOutOfRangeException("Id not exists");
                }

                _categoriaComponent.Delete(categoria);

                response = Ok();
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }
    }
}