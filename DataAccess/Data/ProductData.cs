using DataAccess.DbAccess;
using DataAccess.Models;
using System.Linq;

namespace DataAccess.Data
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _dataAccess;

        public ProductData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<IEnumerable<ProductModel>> GetAllProducts() =>
            _dataAccess.LoadData<ProductModel, dynamic>("spProducts_GetAll", new { });

        public Task<IEnumerable<ProductModel>> GetOrderedProducts(bool isDesc) =>
           _dataAccess.LoadData<ProductModel, dynamic>("spProducts_GetOrderByPrice", new { isDesc });

        public async Task<ProductModel?> GetProduct(int id)
        {
            var result = await _dataAccess.LoadData<ProductModel, dynamic>("spProducts_Get", new { id });

            return result.FirstOrDefault();
        }

        public Task<int> CreateProduct(ProductModel productModel) =>
             _dataAccess.SaveData("spProducts_Create",
                new { productModel.Name,
                      productModel.Price,
                      productModel.Description,
                      productModel.Quantity
                    });

        public async Task<int> UpdateProduct(ProductModel productModel) =>
            await _dataAccess.SaveData("spProducts_Update", productModel);

        public async Task<int> DeleteProduct(int id) =>
            await _dataAccess.SaveData("spProducts_Delete", new { Id = id });
    }
}
