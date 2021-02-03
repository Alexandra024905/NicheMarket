﻿using AutoMapperConfiguration;
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
        private readonly IProductService productService;
        public ProductController(ICloudinaryService cloudinaryService, IProductService productService)
        {
            this.cloudinaryService = cloudinaryService;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await productService.AllProducts());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("Product/Create")]
        public async Task<IActionResult> Create(CreateProductBindingModel createProductBindingModel)
        {
            ProductServiceModel productServiceModel = createProductBindingModel.To<ProductServiceModel>();
            if (createProductBindingModel.FileUpload != null)
            {
                string url = await this.cloudinaryService.UploadImage(createProductBindingModel.FileUpload);
                productServiceModel.imageURL = url;
            }

            bool result = await productService.CreateProduct(productServiceModel);

            return Redirect("/Product/");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return View(await productService.DetailsProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductBindingModel product)
        {
            ProductServiceModel serviceModel = product.To<ProductServiceModel>();
            await productService.EditProduct(serviceModel);
            //redurect To Home.Index
            return Redirect("/Product/");
        }

        public async Task<IActionResult> Details(string id)
        {
            ProductBindingModel product = await productService.DetailsProduct(id);
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

