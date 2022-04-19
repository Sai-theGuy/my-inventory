using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LifeLine.Data;
using LifeLine.Models;

namespace MySuppliers.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Suppliers.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Suppliers record)
        {
            var item = new Suppliers()
            {
                CompanyName = record.CompanyName,
                ContactPerson = record.ContactPerson,
                Address = record.Address,
                Type = record.Type,
                Active = record.Active
            };

            _context.Suppliers.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Suppliers.Where(i => i.SupplierID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Suppliers record)
        {
            var item = _context.Suppliers.Where(i => i.SupplierID == id).SingleOrDefault();
            item.CompanyName = record.CompanyName;
            item.ContactPerson = record.ContactPerson;
            item.Address = record.Address;
            item.Type = record.Type;
            item.Active = record.Active;

            _context.Suppliers.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var item = _context.Suppliers.Where(i => i.SupplierID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _context.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
