using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace be_ecom_shop.Model
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Products> Products { get; set; }
    }
}
