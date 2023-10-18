using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProcurementProcess.Net6.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        [DisplayName("Vendor")]
        public string? Name { get; set; }
        public string Address { get; set;}
        public string Contact { get; set;}

        [DataType(DataType.PhoneNumber), MinLength(11), MaxLength(11)]
        public string PhoneNumber { get; set;}
    }
}
