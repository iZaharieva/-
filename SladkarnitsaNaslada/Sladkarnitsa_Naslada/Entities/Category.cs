using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
