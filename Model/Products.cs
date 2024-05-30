using be_ecom_shop.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace be_ecom_shop.Model
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRatings { get; set; }
        public string Comments { get; set; }
    }
}
