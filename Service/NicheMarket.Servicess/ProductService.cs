using NicheMarket.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NicheMarket.Data;
using NicheMarket.Data.Models;
using AutoMapperConfiguration;
using Microsoft.EntityFrameworkCore;
using NicheMarket.Web.Models.BindingModels;

namespace NicheMarket.Services
{
    public class ProductService : IProductService
    {

        private readonly NicheMarketDBContext dBContext;

        public ProductService(NicheMarketDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<ProductBindingModel>> AllProducts()
        {
            List<ProductBindingModel> products = new List<ProductBindingModel>();

            foreach (var product in dBContext.Products)
            {
                products.Add(product.To<ProductBindingModel>());
            }
            return products;
        }

        public async Task<bool> CreateProduct(ProductServiceModel productServiceModel)
        {
            Product newProduct = productServiceModel.To<Product>();

            newProduct.Id = Guid.NewGuid().ToString();

            bool result = await this.dBContext.AddAsync(newProduct) != null;

            await this.dBContext.SaveChangesAsync();

            return result;
        }

        public Task<bool> DeleteProduct(ProductServiceModel productServiceModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductBindingModel> DetailsProduct(string id)
        {
            Product product = await dBContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            return product.To<ProductBindingModel>();
        }

        public async Task<bool> EditProduct(ProductServiceModel productServiceModel)
        {
            bool result=true;
            if (productServiceModel.Id != null)
            {
                Product product = await dBContext.Products.FirstOrDefaultAsync(p=> p.Id == productServiceModel.Id);
                result =  dBContext.Products.Update(product) != null;
                 dBContext.SaveChanges();
            }
            return result;
        }

        public async Task<Product> FindProduct(string id)
        {
            return await dBContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
