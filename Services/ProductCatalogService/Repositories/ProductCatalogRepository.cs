using System.Text.Json;
using ProductCatalogService.Models;

namespace ProductCatalogService.Repositories;

public class ProductCatalogRepository
{
    //private readonly string _filePath = "Data/products.json";
    private readonly string _filePath = "D:/dotnetCore/OnlineShoppingPortal/Data/products.json";

    public List<Product> GetProducts()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Product>();
        }

        var json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Product>>(json)
               ?? new List<Product>();
    }

    public void SaveProducts(List<Product> products)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(products, options);

        File.WriteAllText(_filePath, json);
    }
}
