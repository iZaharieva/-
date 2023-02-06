using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SladkarnitsaNaslada.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        [Required]
        public int MakerId { get; set; }
        [Required]
        public virtual Maker Maker { get; set; }
        [Required]
        public int Description { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();







    }
}
