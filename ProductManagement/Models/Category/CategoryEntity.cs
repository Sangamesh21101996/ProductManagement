using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Models.Category
{
    [Table("category")]
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be 1-100")]
        public int DisplayOrder { get; set; }

    }
}
