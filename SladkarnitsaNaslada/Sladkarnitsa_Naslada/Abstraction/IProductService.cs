using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Abstraction
{
    public interface IProductService
    {
        bool Create(string name, int categoryId, int makerId, string description, string photo, decimal price, int quantity, decimal discount);
        bool Update(int productId, string name, int categoryId, int makerId, string description, string photo, decimal price, int quantity, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringMakerName);
    }
}
