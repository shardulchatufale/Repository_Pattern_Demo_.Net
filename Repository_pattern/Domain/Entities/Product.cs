using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_pattern.Domain.Entities
{
    public class Product
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("product_name")]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty; // Ensure it's never null

        [Column("price", TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [Column("product_category_id")]
        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryId { get; set; }

        [InverseProperty(nameof(ProductCategory.Products))] // Ensure EF Core recognizes relationship
        public virtual ProductCategory ProductCategory { get; set; } = null!;
    }
}
