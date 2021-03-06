﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicheMarket.Web.Models.BindingModels
{
    public class CreateProductBindingModel 
    {
        public string Title { get; set; }
        public IFormFile FileUpload { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
