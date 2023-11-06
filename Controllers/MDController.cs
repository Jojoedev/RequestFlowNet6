using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Controllers
{
    public class MDController : Controller
    {
        private readonly IGenericInterface<RequestStatus> _status;
        private readonly IGenericInterface<Vendor> _vendor;
        private readonly IGenericInterface<Department> _department;
        private readonly IGenericInterface<Request> _request;
        private readonly ISpecificInterface _specificInterface;

        public MDController(IGenericInterface<RequestStatus> status, IGenericInterface<Vendor> vendor,
                            IGenericInterface<Department> department, IGenericInterface<Request> request,
                            ISpecificInterface specificInterface)
        {
           _status = status;
            _vendor = vendor;
            _department = department;
            _request = request;
            _specificInterface = specificInterface;

        }

        public SelectList VendorList { get; set; }
        public SelectList DepartmentList { get; set; }
        public SelectList StatusList { get; set; }


        public IActionResult Index()
        {
            LoadData();
            var requestList = _request.GetList().Where(x => x.TotalAmount >= 1500000);

            return View(requestList);
        }

        public ActionResult Edit(int id)
        {
            LoadData();
            var item = _request.GetEntity(id);
            if(item == null)
            {
                return null;
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                _request.UpdateAsync(request);
            }
            return RedirectToAction("Index");


        }



        public void LoadData()
        {
            ViewBag.VendorList = new SelectList(_vendor.GetList(), "Id", "Name");
            ViewBag.DepartmentList = new SelectList(_department.GetList(), "Id", "Name");
            ViewBag.StatusList = new SelectList(_status.GetList(), "Id", "Status");
        }
    }
}
