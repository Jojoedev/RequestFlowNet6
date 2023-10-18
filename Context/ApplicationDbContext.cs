using Microsoft.EntityFrameworkCore;
using ProcurementProcess.Net6.Controllers;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Request> Requests { get; set; }    
        public DbSet<Department> Departments { get; set; }    
        public DbSet<Vendor> Vendors { get; set; }    
        public DbSet<RequestStatus> RequestStatuses { get; set; }    


    }
}
