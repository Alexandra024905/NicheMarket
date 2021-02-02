using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NicheMarket.Web.Models.BindingModels
{
    public class ProductBindingModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FileUpload { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

    }
}
