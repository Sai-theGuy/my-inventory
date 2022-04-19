using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LifeLine.Data;
using LifeLine.Models;

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
            var list = _context.Items.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductListings record)
        {
            var item = new ProductListings()
            {
                ProductName = record.ProductName,
                Description = record.Description,
                Price = record.Price,
                SupplierID = record.SupplierID,

                Type = record.Type
            };

            _context.ProductListings.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Items.Where(i => i.ListingID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int? id, OrderItems record)
        {
            var item = _context.Items.Where(i => i.ListingID == id).SingleOrDefault();
            item.Name = record.Name;
            item.Code = record.Code;
            item.Description = record.Description;
            item.Price = record.Price;
            item.DateModified = System.DateTime.Now;
            item.Type = record.Type;

            _context.Items.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            { 
                return RedirectToAction("Index");
            }
            var item = _context.Items.Where(i => i.ListingID == id).SingleOrDefault();
            if(item == null)
            {
                return RedirectToAction("Index");
            }

            _context.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
