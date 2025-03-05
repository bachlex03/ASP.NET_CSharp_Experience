using DB.Mongo.Domain.Abstractions;
using DB.Mongo.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace DB.Mongo.Controllers;


[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly IMongoRepository<Product> _productRepository;

    public SampleController(IMongoRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost("products")]
    public async Task CreateProduct(string productName, string productDescript)
    {
        var newProduct = new Product()
        {
            Name = productName,
            Description = productDescript,
            Price = 100
        };

        await _productRepository.InsertOneAsync(newProduct);
    }

    [HttpGet("products")]
    public IEnumerable<string> GetProducts()
    {
        var products = _productRepository.FilterBy(filter => filter.Price == 100, projection => projection.Name);

        return products;
    }
}
