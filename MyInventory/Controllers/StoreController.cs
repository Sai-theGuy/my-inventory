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
        public IActionResult AddToCart(String ProductName, String Description, Decimal Price, int Quantity)
        {
            List<Object> cart = new List<Object>();
            cart.Add(ProductName);
            cart.Add(Description);
            cart.Add(Price);
            cart.Add(Quantity);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));

            var products = _context.ProductListings.ToList();

            var model = new StoreViewModel
            {
                ProductList = products
            };

            return View(model);
        }
    }
}
