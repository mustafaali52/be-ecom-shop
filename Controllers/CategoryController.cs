using be_ecom_shop.Data;
using be_ecom_shop.DTOs;
using be_ecom_shop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_ecom_shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        public ApplicationDbContext _db;
        public ResponseDto _responseDto = new ResponseDto();
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Category> categories =
               _db.Categories.Include(p => p.Products)
               .OrderBy(c => c.DisplayOrder)
               .OrderBy(c => c.CategoryName)
               .Select(x => x);

                List<CategoryDto> categoryDtoList = new List<CategoryDto>();
                foreach (var category in categories) {
                    CategoryDto catDto = new CategoryDto();
                    catDto.categoryId = category.categoryId;
                    catDto.CategoryName = category.CategoryName;
                    catDto.DisplayOrder = category.DisplayOrder;
                    catDto.Products = new List<ProductsDto>();
                    foreach (var prod in category.Products)
                    {
                        ProductsDto productDto = new ProductsDto();
                        productDto.Id = prod.Id;
                        productDto.ProductName = prod.ProductName;
                        productDto.ProductDescription = prod.ProductDescription;
                        productDto.ProductRatings = prod.ProductRatings;
                        productDto.ProductPrice = prod.ProductPrice;
                        productDto.Comments = prod.Comments;
                        catDto.Products.Add(productDto);
                    }

                    categoryDtoList.Add(catDto);
                }

                _responseDto.Result = categoryDtoList;
                _responseDto.Success = true;
                _responseDto.StatusCode = System.Net.HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;

        }

        [HttpPost]
        public ResponseDto Post(Category category)
        {
            try
            {
                _db.Categories.Add(category);
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
