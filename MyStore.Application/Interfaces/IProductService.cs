using MyStore.Application.DTOs;
namespace MyStore.Application.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
    Task<ProductResponse?> GetProductByIdAsync(Guid id);
    Task<Guid> CreateProductAsync(ProductRequest request);
    Task<bool> UpdateProductAsync(Guid id, ProductRequest request);
    Task<bool> DeleteProductAsync(Guid id);
}