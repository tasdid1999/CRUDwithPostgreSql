using ClientEntity.product;
using Infrastructure.ProductRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.product;

namespace PostgreAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _productService.GetAll();

            return list is null ? NotFound() : Ok(list);
        }
        [HttpGet("{id:int}")]
        
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var product = await _productService.GetById(id);

            return product is null ? NotFound() : Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequestDto request)
        {
            var isCreated = await _productService.Create(request);

            return isCreated ? Ok(isCreated) : NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductRequestDto request, [FromRoute]int id)
        {
            var isUpdated = await _productService.Update(request,id);

            return isUpdated ? Ok(isUpdated) : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var isUpdated = await _productService.Delete(id);

            return isUpdated ? Ok(isUpdated) : NotFound();
        }

    }
}
