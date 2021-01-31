using Microsoft.AspNetCore.Mvc;
using NicheMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicheMarket.Web.Controllers
{
    public class ProductController : Controller
    {
        private ICloudinaryService cloudinaryService;
        public ProductController ()
        { }
        public IActionResult Index()
        {
            return View();
        }



            [HttpPost("//Create/Prpoduct")]
        public async Task<IActionResult> CreateProduct ()
        {


                return Redirect("/");
            }
    }
}
