using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository(StoreContext context) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetProductsAsync() => await context.Products.ToListAsync();
    public async Task<Product?> GetProductByIdAsync(int id) => await context.Products.FindAsync(id);
    public void CreateProduct(Product product) => context.Products.Add(product);
    public void DeleteProduct(Product product) => context.Products.Remove(product);
    public void UpdateProduct(Product product) => context.Entry(product).State = EntityState.Modified;
    public bool ProductExists(int id) => context.Products.Any(x => x.Id == id);
    public async Task<bool> IsSaveChangesAsync() => await context.SaveChangesAsync() > 0;
    public Task<IReadOnlyList<string>> GetBrandsAsync() => throw new NotImplementedException();
    public Task<IReadOnlyList<string>> GetTypesAsync() => throw new NotImplementedException();
    public Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort) => throw new NotImplementedException();
}