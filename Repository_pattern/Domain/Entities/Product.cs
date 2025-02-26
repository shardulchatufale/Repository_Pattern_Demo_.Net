using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Price { get; set; }

    public int ProductCategoryId { get; set; } 
}
