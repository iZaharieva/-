using Sladkarnitsa_Naslada.Abstraction;
using Sladkarnitsa_Naslada.Data;
using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, int categoryId, int makerId, string description, string photo, decimal price, int quantity, decimal discount)
        {
            Product item = new Product
            {
                Name = name,
                Category = _context.Categories.Find(categoryId),
                Maker = _context.Makers.Find(makerId),
                Description = description,
                Photo = photo,
                Price = price,
                Quantity = quantity,
                Discount = discount
            };
            _context.Products.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }

        public List<Product> GetProducts(string searchStringCategoryName, string searchStringMakerName)
        {
            List<Product> products = _context.Products.ToList();
            if (!String.IsNullOrEmpty(searchStringCategoryName) && !String.IsNullOrEmpty(searchStringMakerName))
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower()) && x.Maker.MakerName.ToLower().Contains(searchStringMakerName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringCategoryName))
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringMakerName))
            {
                products = products.Where(x => x.Maker.MakerName.ToLower().Contains(searchStringMakerName.ToLower())).ToList();
            }
            return products;
        }

        public bool RemoveById(int productId)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            _context.Remove(product);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int productId, string name, int categoryId, int makerId, string description, string photo, decimal price, int quantity, decimal discount)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            product.Name = name;
            product.CategoryId = categoryId;
            product.MakerId = makerId;
            product.Category = _context.Categories.Find(categoryId);
            product.Maker = _context.Makers.Find(makerId);
            product.Description = description;
            product.Photo = photo;
            product.Price = price;
            product.Quantity = quantity;
            product.Discount = discount;

            _context.Update(product);
            return _context.SaveChanges() != 0;
        }
    }
}
