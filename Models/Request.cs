using ProcurementProcess.Net6.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementProcess.Net6.Models
{
    public class Request : BaseClass
    {

        public DateTime CreatedDate { get; set; }
        public int? DepartmentId { get; set; }
       
        public Department? Department { get; set; }

        public string RequesterName { get; set; }
        public int? VendorId { get; set; }
       
        public Vendor? Vendor { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public int? RequestStatusId { get; set; }

        public RequestStatus? RequestStatus { get; set; }

        public string? Comment { get; set; }

        public string? LineManager { get; set; }
        public string? FinanceDirector { get; set; }
        public string? ManagingDirector { get; set; }

    }
}
