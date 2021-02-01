using AutoMapperConfiguration;
using Microsoft.AspNetCore.Mvc;
using NicheMarket.Services;
using NicheMarket.Services.Models;
using NicheMarket.Web.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicheMarket.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;
        public ProductController(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}


    }
}
