using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository repo) : ControllerBase
{
    // [HttpGet]
    // public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts() => Ok(await repo.GetProductsAsync());

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort) => Ok(await repo.GetProductsByFiltersAsync(brand, type, sort));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.CreateProduct(product);

        if (await repo.IsSaveChangesAsync())
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

        return BadRequest("Problem creating product");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (product.Id != id || !ProductExists(id))
            return BadRequest("Cannot update this product");

        repo.UpdateProduct(product);

        if (await repo.IsSaveChangesAsync())
            return NoContent();
        return BadRequest("Problem updating the product");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await repo.GetProductByIdAsync(id);
        
        if (product == null) return NotFound();

        repo.DeleteProduct(product);

        if (await repo.IsSaveChangesAsync())
            return NoContent();
        return BadRequest("Problem deleting the product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands() => Ok(await repo.GetBrandsOfTheProductsAsync());

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes() => Ok(await repo.GetTypesOfTheProductsAsync());
    
    private bool ProductExists(int id) => repo.ProductExists(id);
}