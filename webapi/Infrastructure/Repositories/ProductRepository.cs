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
    public async Task<IReadOnlyList<string>> GetBrandsOfTheProductsAsync() => await context.Products.Select(x => x.Brand).Distinct().ToListAsync();
    public async Task<IReadOnlyList<string>> GetTypesOfTheProductsAsync() => await context.Products.Select(x => x.Type).Distinct().ToListAsync();
    public Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort) => throw new NotImplementedException();
}