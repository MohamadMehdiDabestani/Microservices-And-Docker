using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IProductServices _product;
        private readonly ILogger<CatalogController> log;

        public CatalogController(IProductServices _product, ILogger<CatalogController> log)
        {
            this._product = _product;
            this.log = log;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>) , (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProduct()
        {
            var res = await _product.GetProducts();
            return Ok(res);
        }
        [HttpGet("{id:length(24)}" , Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProduct(string id)
        {
            var res = await _product.GetProduct(id);
            if(res == null)
            {
                log.LogError($"product with id {id}, not found");
                return NotFound();
            }
            return Ok(res);
        }
        [HttpGet("/GetProductByCategory/{category}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            var res = await _product.GetProductsByCategory(category);
            return Ok(res);
        }
        [HttpGet("/GetProductByName/{name}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var res = await _product.GetProductsByName(name);
            return Ok(res);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Product) , (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _product.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id } , product);
        }
        [HttpPut]
        [ProducesResponseType(typeof(bool),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] Product p)
        {
            return Ok(await _product.UpdateProduct(p));
        }
        [Route("{id:length(24)}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _product.DeleteProduct(id));
        }
    }
}
