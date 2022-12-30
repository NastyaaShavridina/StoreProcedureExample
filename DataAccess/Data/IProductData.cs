using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IProductData
    {
        Task<int> CreateProduct(ProductModel productModel);
        Task<int> DeleteProduct(int id);
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<IEnumerable<ProductModel>> GetOrderedProducts(bool isDesc);
        Task<ProductModel?> GetProduct(int id);
        Task<int> UpdateProduct(ProductModel productModel);
    }
}