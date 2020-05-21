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
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoComponent _produtoComponent;
        private readonly CategoriaComponent _categoriaComponent;

        public ProdutoController(ProdutoComponent produtoComponent, CategoriaComponent categoriaComponent)
        {
            _produtoComponent = produtoComponent;
            _categoriaComponent = categoriaComponent;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            ActionResult response;

            try
            {
                var produto = _produtoComponent.GetAll();

                response = Ok(produto);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex);
            }

            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            ActionResult response;

            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException("Id is required");
                }

                var produto = _produtoComponent.GetById(id);

                if (produto == null || produto.idProduto == 0)
                    return NotFound();

                response = Ok(produto);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex);
            }

            return response;
        }

        [HttpPost]
        public void Post(Produto produto)
        {
            try
            {
                if (produto.idCategoria == 0)
                {
                    throw new ArgumentNullException("IdCategoria is required");
                }

                var categoria = _categoriaComponent.GetById(produto.idCategoria);

                if (categoria == null || categoria.idCategoria == 0)
                {
                    throw new ArgumentOutOfRangeException("idCategoria not exist");
                }

                _produtoComponent.Insert(produto);

                Ok();
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }

        [HttpPut]
        public void Put([FromBody] Produto produto)
        {
            if (produto.idProduto == 0)
            {
                throw new ArgumentNullException("IdProduto is required");
            }

            if (produto.idCategoria == 0)
            {
                throw new ArgumentNullException("IdCategoria is required");
            }

            try
            {
                var categoria = _categoriaComponent.GetById(produto.idCategoria);

                if (categoria == null || categoria.idCategoria == 0)
                {
                    throw new ArgumentOutOfRangeException("idCategoria not exist");
                }

                _produtoComponent.Update(produto);

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

            if (id == 0)
            {
                throw new ArgumentNullException("Id is required");
            }

            try
            {
                var produto = _produtoComponent.GetById(id);

                if (produto == null || produto.idProduto == 0)
                {
                    throw new ArgumentOutOfRangeException("Id not exist");
                }

                _produtoComponent.Delete(produto);

                Ok();
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }
    }
}