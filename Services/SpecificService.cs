using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;

namespace ProcurementProcess.Net6.Services
{
    public class SpecificService : ISpecificInterface
    {
        private readonly IGenericInterface<Department> _department;
        private readonly IGenericInterface<Vendor> _vendor;
        private readonly IGenericInterface<RequestStatus> _requestStatus;
        public SpecificService(IGenericInterface<Department> department,
            IGenericInterface<Vendor> vendor,
            IGenericInterface<RequestStatus> requestStatus)
        {
            _department = department;
            _vendor = vendor;
            _requestStatus = requestStatus;
        }

        public void LoadDropDown()
        {
            _requestStatus.GetList().ToLookup(x => x.Status);
            _department.GetList().ToLookup(x => x.Name);
            _vendor.GetList().ToLookup(x => x.Name);
        }
    }
}
