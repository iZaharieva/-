using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Abstraction
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Product> GetProductsByCategory(int categoryId);
    }
}
