using NicheMarket.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NicheMarket.Data;
using NicheMarket.Data.Models;
using AutoMapperConfiguration;

namespace NicheMarket.Services
{
    public class ProductService : IProductService
    {

        private readonly NicheMarketDBContext dBContext;

        public ProductService(NicheMarketDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<bool> CreateProduct(ProductServiceModel productServiceModel)
        {
            Product newProduct = productServiceModel.To<Product>();

            newProduct.Id = Guid.NewGuid().ToString();

            bool result = await this.dBContext.AddAsync(newProduct) != null;

            await this.dBContext.SaveChangesAsync();

            return result;
        }

    }
}
