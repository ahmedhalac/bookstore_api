using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository) 
    {
        _productRepository = productRepository;
    }

    [HttpGet("GetProducts")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        List<Product> products = await _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("GetProduct/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.Get(id);
        if(product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
    {
        Product addedProduct = await _productRepository.Add(product);
        return CreatedAtAction("GetProducts", new {id = addedProduct.Id}, addedProduct);
    }


}

