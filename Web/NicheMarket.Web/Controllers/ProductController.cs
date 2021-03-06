﻿using AutoMapperConfiguration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NicheMarket.Data.Models;
using NicheMarket.Services;
using NicheMarket.Services.Models;
using NicheMarket.Web.Models.BindingModels;
using NicheMarket.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicheMarket.Web.Controllers
{
   // [Authorize]
    public class ProductController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly IProductService productService;
        public ProductController(ICloudinaryService cloudinaryService, IProductService productService)
        {
            this.cloudinaryService = cloudinaryService;
            this.productService = productService;
        }

      //  [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await productService.AllProducts());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductBindingModel createProductBindingModel)
        {
            ProductServiceModel productServiceModel = createProductBindingModel.To<ProductServiceModel>();
            if (createProductBindingModel.FileUpload != null)
            {
                string url = await this.cloudinaryService.UploadImage(createProductBindingModel.FileUpload);
                productServiceModel.ImageURL = url;
            }
            else
            {
                productServiceModel.ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png";
                
            }

            bool result = await productService.CreateProduct(productServiceModel);

            return Redirect("/Product");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return View(await productService.GetProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductBindingModel product)
        {
            ProductServiceModel serviceModel = product.To<ProductServiceModel>();
            if (product.Image != null)
            {
                string url = await this.cloudinaryService.UploadImage(product.Image);
                serviceModel.ImageURL = url;
            }
            await productService.EditProduct(serviceModel);
            //To do : redurect To Home.Index
            return Redirect("/Product");
        }

       
      //  [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            ProductViewModel product = await productService.DetailsProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return View(await productService.DetailsProduct(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await productService.DeleteProduct(id);
            return Redirect("/Product");
        }
    }

}

