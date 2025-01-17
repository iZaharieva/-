﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Models.Product
{
    public class ProductIndexVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public int DesignerId { get; set; }
        [Display(Name = "Maker")]
        public string MakerName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }


        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
