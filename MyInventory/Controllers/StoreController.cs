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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        public IActionResult Detail(int? id)
        {
            var products = _context.ProductListings.Where(d => d.ListingID == id).ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int? id, int? quantity)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var products = _context.ProductListings
                .Where(p => p.ListingID == id).SingleOrDefault();
            
            if(products == null)
            {
                return RedirectToAction("Index");
            }

            var shoppingCart = _context.ShoppingCart
                .Where(d => d.ListingID == id).SingleOrDefault();

            if(shoppingCart != null)
            {
                var record = new ShoppingCart
                {
                    ListingID = products.ListingID,
                    ProductName = products.ProductName,
                    Quantity = quantity == null ? 1 : (int)quantity,
                    Price = products.Price,
                };

                _context.ShoppingCart.Add(record);
            }
            else
            {
                shoppingCart.Quantity = shoppingCart.Quantity + quantity == null ? 1 :
                    (int)quantity;
                shoppingCart.Price = shoppingCart.Price + quantity == null ? products.Price :
                    (int)quantity * products.Price;
            }
            _context.SaveChanges();

            var list = _context.ProductListings.ToList();

            var model = new StoreViewModel
            {
                ProductList = list
            };

            return View(model);
        }


    }
}
