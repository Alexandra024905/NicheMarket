using NicheMarket.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicheMarket.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductServiceModel productServiceModel);
    }
}
