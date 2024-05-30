using be_ecom_shop.Model;
using System.ComponentModel.DataAnnotations;

namespace be_ecom_shop.DTOs
{
    public class CategoryDto
    {
        public int categoryId { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
        public List<ProductsDto> Products { get; set; }
    }
}
