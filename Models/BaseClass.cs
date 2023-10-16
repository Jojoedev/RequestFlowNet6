namespace ProcurementProcess.Net6.Models
{
    public class BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal TotalAmount { get; set; }

    }

}
