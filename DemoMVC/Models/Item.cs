using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models;
public class Item
{

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [DisplayName("Item Name")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]

    public string Name { get; set; }
    [DataType(DataType.Currency, ErrorMessage = "Price must be a number")]
    [Range(0, 20000, ErrorMessage = "Price must be between 0 and 1000")]
    [DisplayFormat(DataFormatString = "{0:C} $")]
    public double Price { get; set; } = 0;
  
  [StringLength(250, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 250 characters")]
    public string Description { get; set; }
    public ItemSpecs? Specs { get; set; }
}