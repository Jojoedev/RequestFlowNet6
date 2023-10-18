using System.ComponentModel;

namespace ProcurementProcess.Net6.Models
{
    public class Department
    {
        public int Id { get; set; }

        [DisplayName("Department")]
        public string? Name { get; set; }
    }
}
