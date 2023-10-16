using ProcurementProcess.Net6.Controllers;

namespace ProcurementProcess.Net6.Models
{
    public class Request : BaseClass
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }

    }
}
