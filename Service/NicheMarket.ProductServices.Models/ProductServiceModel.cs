using AutoMapperConfiguration;
using NicheMarket.Data.Models;
using NicheMarket.Web.Models.BindingModels;
using System;

namespace NicheMarket.Services.Models
{
    public class ProductServiceModel : IMapTo<Product>, IMapTo<ProductBindingModel>,IMapFrom<CreateProductBindingModel>, IMapTo<ProductServiceModel>
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string imageURL { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
    }
}
