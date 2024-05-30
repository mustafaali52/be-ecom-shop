using be_ecom_shop.Model;
using System.ComponentModel.DataAnnotations;

namespace be_ecom_shop.DTOs
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public CategoryDto Category { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRatings { get; set; }
        public string Comments { get; set; }
    }
}
