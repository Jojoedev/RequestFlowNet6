using Microsoft.AspNetCore.Mvc;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Controllers
{
    public class StatusController : Controller
    {
        private readonly IGenericInterface<RequestStatus> _status;

        public StatusController(IGenericInterface<RequestStatus> status)
        {
            _status = status;
        }


        public IActionResult Index()
        {
            var statusList = _status.GetList();
            return View(statusList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RequestStatus requestStatus)
        {
           

            if (ModelState.IsValid)
            {
                _status.CreateAsync(requestStatus);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
