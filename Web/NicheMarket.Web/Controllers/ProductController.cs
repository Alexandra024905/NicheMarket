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


        //// GET: Products/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}


        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,Title,imageURL,Type,Description")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }

}

