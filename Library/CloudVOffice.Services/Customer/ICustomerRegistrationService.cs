using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Customer;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Customer;
using CloudVOffice.Data.DTO.Pandit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Customer
{
    public interface ICustomerRegistrationService
    {
        public MessageEnum CustomerRegistrationCreate(CustomerRegistrationDTO customerRegistrationDTO);
        public MessageEnum CustomerRegistrationUpdate(CustomerRegistrationDTO customerRegistrationDTO);
        public MessageEnum DeleteCustomerRegistration(int CustomerRegistrationId, Int64 DeletedBy);
        public List<CustomerRegistration> GetCustomerRegistrationList();
        public CustomerRegistration GetCustomerRegistrationById(int CustomerRegistrationId);
    }
}
