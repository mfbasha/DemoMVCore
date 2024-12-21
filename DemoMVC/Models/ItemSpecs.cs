using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Models
{
    public class ItemSpecs
    {
        [Key]
        [Description("Item Specs Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Item Specs Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Item Specs Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }
        [DisplayName("Item Specs Description")]
        public string Description { get; set; }
        [Range(0,50000, ErrorMessage = "Item Count must be between 0 and 50000")]
        [DisplayName("Items  Count")]
        public double ItemCount{ get; set; }

        public int? itemId { get; set; }

    [ForeignKey("itemId")]
        public Item? item{ get; set; }
    }
}