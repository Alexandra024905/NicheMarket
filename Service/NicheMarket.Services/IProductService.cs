using NicheMarket.Data.Models;
using NicheMarket.Services.Models;
using NicheMarket.Web.Models.BindingModels;
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
        Task<bool> DeleteProduct(ProductServiceModel productServiceModel);
        Task<bool> EditProduct(ProductServiceModel productServiceModel);
        Task <ProductBindingModel> DetailsProduct(string id);
        Task <List<ProductBindingModel>> AllProducts();
    }
}
