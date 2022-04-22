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

        public IActionResult ShowCart()
        {
            var cort = _context.ShoppingCart.ToList();
            return View(cort);
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

            if(shoppingCart == null)
            {
                var record = new ShoppingCart
                {
                    ListingID = products.ListingID,
                    ProductName = products.ProductName,
                    Quantity = quantity == null ? 1 : (int)quantity,
                    Price = products.Price * (int)quantity,
                };
                
                _context.ShoppingCart.Add(record);
            }
            else
            {
                shoppingCart.Quantity += (int)quantity;
                shoppingCart.Price += (int)quantity * products.Price;
            }
            _context.SaveChanges();

            var list = _context.ProductListings.ToList();

            var model = new StoreViewModel
            {
                ProductList = list
            };

            return RedirectToActionPermanent("StoreView");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ShowCart");
            }
            var item = _context.ShoppingCart.Where(i => i.ShoppingCartID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("ShowCart");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int? id, ShoppingCart record)
        {
            var item = _context.ShoppingCart.Where(i => i.ShoppingCartID == id).SingleOrDefault();
            decimal price = item.Price/item.Quantity;
            item.Quantity = record.Quantity;
            item.Price = record.Quantity * price;

            _context.ShoppingCart.Update(item);
            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ShowCart");
            }
            var item = _context.ShoppingCart.Where(i => i.ShoppingCartID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("ShowCart");
            }

            _context.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }

        public IActionResult Order()
        {
            var cartItems = _context.ShoppingCart.ToList();
            if (cartItems == null)
            {
                return RedirectToAction("ShowCart");
            }
            var newPurchaseOrder = new PurchaseOrders();
            foreach(var item in cartItems)
            {
                newPurchaseOrder.Price += item.Price;
            }
            _context.PurchaseOrders.Add(newPurchaseOrder);
            _context.SaveChanges();

            var purchaseOrders = _context.PurchaseOrders
                .OrderByDescending(i => i.OrderID).FirstOrDefault();
            if (purchaseOrders == null)
            {
                return RedirectToAction("ShowCart");
            }

            foreach (var item in cartItems)
            {
                var newOrderItems = new OrderItems();
                newOrderItems.ListingID = item.ListingID;
                newOrderItems.Amount = item.Quantity;
                newOrderItems.Price = item.Price;
                newOrderItems.OrderID = purchaseOrders.OrderID;
                _context.OrderItems.Add(newOrderItems);
                _context.SaveChanges();
            }

            var shoppingCart = _context.ShoppingCart.ToList();
            foreach (var shoppingCartItem in shoppingCart)
            {
                _context.ShoppingCart.Remove(shoppingCartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("ShowCart");
        }
    }
}
