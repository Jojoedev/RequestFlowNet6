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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RequestController(IGenericInterface<Request> request, 
            IGenericInterface<Department> department, IGenericInterface<Vendor> vendor,
            IGenericInterface<RequestStatus> requestStatus,
            ISpecificInterface specific,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _request = request;
            _department = department;
            _vendor = vendor;
            _requestStatus = requestStatus;
            _specific = specific;
            _webHostEnvironment = webHostEnvironment;
          
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
        public async Task<IActionResult> Create(Request request)
        {

            request.CreatedDate = DateTime.Now;
            request.TotalAmount = request.Quantity * request.Price;

            if (ModelState.IsValid)
            {
                if(request.Image != null)
                {
                    string folder = "SupportDoc/POrders";

                    folder +=Guid.NewGuid().ToString() + "_" + request.Image.FileName;
                    string savingFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    
                   await request.Image.CopyToAsync(new FileStream(savingFolder, FileMode.Create));
    
                }

                _request.CreateAsync(request);
               
            }
            else
            {
                LoadData();
                return View();
            }
            return RedirectToAction("Index");
        }

        public void LoadData()
        {
           ViewBag.VendorList = new SelectList(_vendor.GetList(), "Id", "Name");
           ViewBag.DepartmentList = new SelectList(_department.GetList(), "Id", "Name");
           ViewBag.StatusList = new SelectList(_requestStatus.GetList(), "Id", "Status");
        }
    }
}
