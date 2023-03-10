using Sladkarnitsa_Naslada.Abstraction;
using Sladkarnitsa_Naslada.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Services
{
    public class StatisticService : IStatisticsService

    {
        private readonly ApplicationDbContext _context;
        public StatisticService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CountClients()
        {
            return _context.Users.Count() - 1;
        }

        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        public int CountProducts()
        {
            return _context.Products.Count();
        }

        public decimal SumOrders()
        {
            return _context.Orders.Sum(x => x.Quantity * x.Price - x.Quantity * x.Price * x.Discount / 100);
        }
    }
}
