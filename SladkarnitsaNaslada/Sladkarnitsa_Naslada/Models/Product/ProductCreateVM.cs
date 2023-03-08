using Sladkarnitsa_Naslada.Models.Category;
using Sladkarnitsa_Naslada.Models.Maker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Models.Product
{
    public class ProductCreateVM
    {
        public ProductCreateVM()
        {
            Makers = new List<MakerPairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(160)]
        [MinLength(10)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]

        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }


        [Required]
        [Display(Name = "Maker")]

        public int MakerId { get; set; }
        public virtual List<MakerPairVM> Makers { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Photo")]

        public string Photo { get; set; }

        [Required]
        [Range(1, 450, ErrorMessage = "Price must be positive in range 1-450.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]

        public decimal Price { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Price must be positive in range 0-100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
