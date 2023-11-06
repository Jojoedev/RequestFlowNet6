using ProcurementProcess.Net6.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementProcess.Net6.Models
{
    public class Request : BaseClass
    {

        [DisplayName("Date")]
        public DateTime CreatedDate { get; set; }
        public int? DepartmentId { get; set; }

        [Display(Name ="Dept")]
        public Department? Department { get; set; }

        [DisplayName("Name")]
        public string RequesterName { get; set; }
        public int? VendorId { get; set; }
       
        public Vendor? Vendor { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public int? RequestStatusId { get; set; }

        [DisplayName("Status")]
        public RequestStatus? RequestStatus { get; set; }

        public string? Comment { get; set; }

        [DisplayName("LM")]
        public string? LineManager { get; set; }

        [DisplayName("FD")]
        public string? FinanceDirector { get; set; }

        [DisplayName("MD")]
        public string? ManagingDirector { get; set; }

    }
}
