using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeLine.Models;
using LifeLine.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Newtonsoft.Json;

namespace LifeLine.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult StoreView()
        {
            var products = _context.ProductListings.ToList();

            var model = new StoreViewModel
            {
                ProductList = products
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddToCart(string id)
        {
            //List<Object> cart = new List<Object>();
            //foreach (var product in order.ProductList)
            //{StoreViewModel order
            //    cart.Add(product.ListingID);
            //    cart.Add(product.ProductName);
            //    cart.Add(product.Price);
            //    cart.Add("placeholder");
            //}

            //HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));

            var products = _context.ProductListings.ToList();

            var model = new StoreViewModel
            {
                ProductList = products
            };

            return View(model);
              
            
        }
    }
}
