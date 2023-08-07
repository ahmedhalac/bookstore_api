using AutoMapper;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
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
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
    {
        Product addedProduct = await _productRepository.Add(product);
        return CreatedAtAction("GetProducts", new { id = addedProduct.Id }, addedProduct);
    }

    [HttpDelete("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productRepository.Delete(id);
        return NoContent();
    }

    [HttpPut("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO, int id)
    {
        if(productDTO == null)
        {
            return BadRequest("Invalid product data");
        }

        Product existingProduct = await _productRepository.Get(id);

        if(existingProduct == null)
        {
            return NotFound();
        }

        _mapper.Map(productDTO, existingProduct);
        await _productRepository.Update(existingProduct);
        return NoContent();
    }


}

