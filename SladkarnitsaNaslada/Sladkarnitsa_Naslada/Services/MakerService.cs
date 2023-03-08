using Sladkarnitsa_Naslada.Abstraction;
using Sladkarnitsa_Naslada.Data;
using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Services
{
    public class MakerService : IMakerService
    {
        private readonly ApplicationDbContext _context;

        public MakerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Maker GetMakerById(int makerId)
        {
            return _context.Makers.Find(makerId);
        }

        public List<Maker> GetMakers()
        {
            List<Maker> makers = _context.Makers.ToList();
            return makers;
        }

        public List<Product> GetProductsByMaker(int makerId)
        {
            return _context.Products
                .Where(x => x.MakerId == makerId)
                .ToList();

        }
    }
}
