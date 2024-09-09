using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Products.Any())
        {
            var seeds = await File.ReadAllTextAsync("..Infrastructure/Data/SeedDatas/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(seeds);

            if (products == null) return;

            context.Products.AddRange(products);

            await context.SaveChangesAsync();
        }
    }
}