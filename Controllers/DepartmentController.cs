using Microsoft.AspNetCore.Mvc;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericInterface<Department> _department;

        public DepartmentController(IGenericInterface<Department> deparment)
        {
            _department = deparment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var deptList = _department.GetList();
            return View(deptList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _department.CreateAsync(department);
                
            }
            return RedirectToAction("Index");
        }
    }
}
