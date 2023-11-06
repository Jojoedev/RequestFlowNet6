using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;
using System.Net.WebSockets;

namespace ProcurementProcess.Net6.Controllers
{
    public class LMController : Controller
    {
        private readonly IGenericInterface<Request> _request;
        private readonly IGenericInterface<Department> _department;
        private readonly IGenericInterface<Vendor> _vendor;
        private readonly IGenericInterface<RequestStatus> _status;
        private readonly ISpecificInterface _specificInterface;

        public LMController(IGenericInterface<Request> request, IGenericInterface<Department> department,
                            IGenericInterface<Vendor> vendor, IGenericInterface<RequestStatus> status,
                            ISpecificInterface specificInterface)
        {
            _request = request;
            _department = department;
            _vendor = vendor;
            _status = status;
            _specificInterface = specificInterface;
        }

        public SelectList VendorList { get; set;}
        public SelectList DepartmentList { get; set;}
        public SelectList StatusList { get; set;}



        public IActionResult Index()
        {
            LoadData();

            var requestList = _request.GetList();

            return View(requestList);
        }

        public void LoadData()
        {
            ViewBag.VendorList = new SelectList(_vendor.GetList(), "Id", "Name");
            ViewBag.DepartmentList = new SelectList(_department.GetList(), "Id", "Name");
            ViewBag.StatusList = new SelectList(_status.GetList(), "Id", "Status");

        }

        
        public ActionResult Review(int id)
        {
            LoadData();
            var editItem = _request.GetEntity(id);
            return View(editItem);
        }

        [HttpPost]
        public ActionResult Review(Request request)
        {
            if (ModelState.IsValid)
            {
                _request.UpdateAsync(request);
            }
            return RedirectToAction("Index");
        }

    }

}
