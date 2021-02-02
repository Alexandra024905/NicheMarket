using AutoMapperConfiguration;
using NicheMarket.Web.Models.BindingModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NicheMarket.Data.Models
{
    public class Product : IMapTo<ProductBindingModel>
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }

        public string imageURL { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

    }
}
