using be_ecom_shop.Data;
using be_ecom_shop.DTOs;
using be_ecom_shop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_ecom_shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        public ApplicationDbContext _db;
        public ResponseDto _responseDto = new ResponseDto();
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                var products = _db.Products.Include(c => c.Category).Select(x => x).ToList();
                List<ProductsDto> productDtoList = new List<ProductsDto>();
                foreach (var product in products)
                {
                    ProductsDto productsDto = new ProductsDto();
                    productsDto.Id = product.Id;
                    productsDto.ProductName = product.ProductName;
                    productsDto.ProductDescription = product.ProductDescription;
                    productsDto.ProductRatings = product.ProductRatings;
                    productsDto.ProductPrice = product.ProductPrice;
                    productsDto.Comments = product.Comments;
                    productsDto.Category = new CategoryDto();
                    productsDto.Category.categoryId = product.Category.categoryId;
                    productsDto.Category.CategoryName = product.Category.CategoryName;
                    productDtoList.Add(productsDto);
                }
                
                
                _responseDto.Result = productDtoList;
                _responseDto.Success = true;
                _responseDto.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex) {
                _responseDto.Success = false;
                _responseDto.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return _responseDto;
        }

        [HttpPost]
        public ResponseDto Post(Products products)
        {
            try
            {
                _db.Products.Add(products);
                _db.SaveChanges();
                _responseDto.Success = true;
                _responseDto.StatusCode = System.Net.HttpStatusCode.OK;
                _responseDto.Message = "Record(s) created successfully!";
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
