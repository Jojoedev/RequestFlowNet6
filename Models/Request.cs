using ProcurementProcess.Net6.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProcurementProcess.Net6.Models
{
    public class Request : BaseClass
    {
        public int? DepartmentId { get; set; }
       
        public Department? Department { get; set; }

        public int? VendorId { get; set; }
       
        public Vendor? Vendor { get; set; }

        public int? RequestStatusId { get; set; }

        public RequestStatus? RequestStatus { get; set; }

        public string? Comment { get; set; }

    }
}
