using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductShop.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        public IProductData _productData { get; set; }

        public ProductController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await _productData.GetAllProducts();

                if (!Equals(result, null))
                {
                    return Ok(result);
                }
                else
                {
                    return this.BadRequest("Get products failed.");
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest($"Get all products. Error message: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ordered/{isDesc}")]
        public async Task<IActionResult> GetOrderedProducts(bool isDesc)
        {
            try
            {
                var result = await _productData.GetOrderedProducts(isDesc);

                if (!Equals(result, null))
                {
                    return Ok(result);
                }
                else
                {
                    return this.BadRequest("Get ordered products failed.");
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest($"Get ordered products. Error message: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var result = await _productData.GetProduct(id);

                if (!Equals(result, null))
                {
                    return Ok(result);
                }
                else
                {
                    return this.BadRequest("Get product by id failed.");
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest($"Get product by id. Error message: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productModel)
        {
            try
            {
                return Ok(await _productData.CreateProduct(productModel));

            }
            catch (Exception ex)
            {
                return this.BadRequest($"Create product failed. Error message: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel productModel)
        {
            try
            {
                return Ok(await _productData.UpdateProduct(productModel));

            }
            catch (Exception ex)
            {
                return this.BadRequest($"Update product failed. Error message: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return Ok(await _productData.DeleteProduct(id));

            }
            catch (Exception ex)
            {
                return this.BadRequest($"Delete product failed. Error message: {ex.Message}");
            }
        }
    }
}
