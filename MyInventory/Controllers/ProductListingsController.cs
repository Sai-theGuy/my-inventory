using LifeLine.Data;
using LifeLine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace LifeLine.Controllers
{
    public class ProductListingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductListingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var list = _context.ProductListings.ToList();
                return View(list);
            }
            else
            {
                return LocalRedirect(Url.Content("/Identity/Account/Login"));
            }
        }
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return LocalRedirect(Url.Content("/Identity/Account/Login"));
            }
        }
        
        [HttpPost]
        public IActionResult Create(ProductListings record, IFormFile ImagePath)
        {
            if (User.Identity.IsAuthenticated)
            {
                var product = new ProductListings()
                {
                    ProductName = record.ProductName,
                    Description = record.Description,
                    Price = record.Price,
                    SupplierID = record.SupplierID,
                    Type = record.Type,
                    StocksLeft = record.StocksLeft,
                    UnitMeasurement = record.UnitMeasurement
                };

                if(ImagePath != null)
                {
                    if(ImagePath.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/img/products", ImagePath.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImagePath.CopyTo(stream);
                        }
                        product.ImagePath = ImagePath.FileName;
                    }
                }

                _context.ProductListings.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return LocalRedirect(Url.Content("/Identity/Account/Login"));
            }
}
        public IActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                var item = _context.ProductListings.Where(i => i.ListingID == id).SingleOrDefault();
                if (item == null)
                {
                    return RedirectToAction("Index");
                }

                return View(item);
            }
            else
            {
                return LocalRedirect(Url.Content("/Identity/Account/Login"));
            }
        }
        [HttpPost]
        public IActionResult Edit(int? id, ProductListings record, IFormFile ImagePath)
        {
            if (User.Identity.IsAuthenticated)
            {
                var product = _context.ProductListings.Where(i => i.ListingID == id).SingleOrDefault();
                product.ProductName = record.ProductName;
                product.Description = record.Description;
                product.SupplierID = record.SupplierID;
                product.Price = record.Price;
                product.Type = record.Type;
                product.StocksLeft = record.StocksLeft;
                product.UnitMeasurement = record.UnitMeasurement;

                if (ImagePath != null)
                {
                    if (ImagePath.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/img/products", ImagePath.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImagePath.CopyTo(stream);
                        }
                        product.ImagePath = ImagePath.FileName;
                    }
                }

                _context.ProductListings.Update(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return LocalRedirect(Url.Content("/Identity/Account/Login"));
            }
}
        public IActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                { 
                    return RedirectToAction("Index");
                }
                var product = _context.ProductListings.Where(i => i.ListingID == id).SingleOrDefault();
                if(product == null)
                {
                    return RedirectToAction("Index");
                }

                _context.Remove(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return LocalRedirect(Url.Content("/Identity/Account/Login"));
            }
        }
    }
}
