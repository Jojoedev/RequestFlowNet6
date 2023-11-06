using System.ComponentModel;

namespace ProcurementProcess.Net6.Models
{
    public class BaseClass
    {
        public int Id { get; set; }

        [DisplayName("Product")]
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Amount")]
        public decimal TotalAmount { get; set; }

       

    }

}
