using Microsoft.AspNetCore.Mvc;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Controllers
{
    public class VendorController : Controller
    {
        private readonly IGenericInterface<Vendor> _vendor;
        public VendorController(IGenericInterface<Vendor> vendor)
        {
           _vendor = vendor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vendors = _vendor.GetList();
            return View(vendors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            { 
                _vendor.CreateAsync(vendor);
               
            }
            return RedirectToAction("Index");
        }
    }
}
