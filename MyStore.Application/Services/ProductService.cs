using MyStore.Application.Interfaces;
using MyStore.Application.DTOs;
using MyStore.Domain.Entities;

namespace MyStore.Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

   public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync() {
        var products = await _repo.GetAllAsync();
        return products.Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.Price, p.Stock));
    }

    public async Task<ProductResponse?> GetProductByIdAsync(Guid id)
    {
        var product = await _repo.GetByIdAsync(id);
        return product != null ? new ProductResponse(product.Id, product.Name, product.Description, product.Price, product.Stock) : null;
    }

   public async Task<Guid> CreateProductAsync(ProductRequest req) {
        var product = new Product { Id = Guid.NewGuid(), Name = req.Name, Description = req.Description, Price = req.Price, Stock = req.Stock };
        await _repo.AddAsync(product);
        return product.Id;
    }

    public async Task<bool> UpdateProductAsync(Guid id, ProductRequest req)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return false;

        product.Name = req.Name;
        product.Description = req.Description;
        product.Price = req.Price;
        product.Stock = req.Stock;

        await _repo.UpdateAsync(product);
        return true;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {       
         var product = await _repo.GetByIdAsync(id);
        if (product == null) return false;

        await _repo.DeleteAsync(id);
        return true;
    }
}