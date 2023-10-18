using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Controllers
{
    public class RequestController : Controller
    {
        private readonly IGenericInterface<Request> _request;
        private readonly IGenericInterface<Department> _department;
        private readonly IGenericInterface<Vendor> _vendor;
        private readonly IGenericInterface<RequestStatus> _requestStatus;
        private readonly ISpecificInterface _specific;

        public RequestController(IGenericInterface<Request> request, 
            IGenericInterface<Department> department, IGenericInterface<Vendor> vendor,
            IGenericInterface<RequestStatus> requestStatus,
            ISpecificInterface specific)
        {
            _request = request;
            _department = department;
            _vendor = vendor;
            _requestStatus = requestStatus;
            _specific = specific;
        }
        
        public SelectList VendorList { get; set; }
        public SelectList DepartmentList { get; set; }
        public SelectList StatusList { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
           _specific.LoadDropDown();
            var requestList = _request.GetList();
            return View(requestList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Request request)
        {
            request.TotalAmount = request.Quantity * request.Price;

            if (ModelState.IsValid)
            {
                _request.CreateAsync(request);

               return RedirectToAction("Index");
            }
            
                
                return View();
            
            //return RedirectToAction("Index");
        }




        public void LoadData()
        {
           ViewBag.VendorList = new SelectList(_vendor.GetList(), "Id", "Name");
           ViewBag.DepartmentList = new SelectList(_department.GetList(), "Id", "Name");
           ViewBag.StatusList = new SelectList(_requestStatus.GetList(), "Id", "Status");
        }
    }
}
