using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_pattern.Domain.Entities
{
    public class ProductCategory
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("category_name")]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [Column("description")]
        [MaxLength(200)]
        public string? Description { get; set; }

        [InverseProperty(nameof(Product.ProductCategory))] // Correct relationship mapping
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
