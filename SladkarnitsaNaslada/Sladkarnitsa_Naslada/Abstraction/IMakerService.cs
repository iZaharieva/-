using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Abstraction
{
    public interface IMakerService
    {
        List<Maker> GetMakers();
        Maker GetMakerById(int makerId);
        List<Product> GetProductsByMaker(int makerId);
    }
}
