using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Customer;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Customer;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Customer
{
    public class CustomerRegistrationService: ICustomerRegistrationService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<CustomerRegistration> _customerRegistrationRepo;
        public CustomerRegistrationService(ApplicationDBContext dbContext, ISqlRepository<CustomerRegistration> customerRegistrationRepo)
        {
            _dbContext = dbContext;
            _customerRegistrationRepo = customerRegistrationRepo;
        }
        public MessageEnum CustomerRegistrationCreate(CustomerRegistrationDTO customerRegistrationDTO)
        {

            try
            {
                var objcheck = _dbContext.CustomerRegistrations.SingleOrDefault(opt => opt.Deleted == false && opt.CustomerName == customerRegistrationDTO.CustomerName);
                if (objcheck == null)
                {
                    CustomerRegistration customerRegistration = new CustomerRegistration();
                    customerRegistration.CustomerName = customerRegistrationDTO.CustomerName;
                    customerRegistration.Address = customerRegistrationDTO.Address;
                    customerRegistration.PrimaryPhone = customerRegistrationDTO.PrimaryPhone;
                    customerRegistration.AlternatePhone = customerRegistrationDTO.AlternatePhone;
                    customerRegistration.MailId = customerRegistrationDTO.MailId;
                    customerRegistration.DateOfBirth = customerRegistrationDTO.DateOfBirth;
                    customerRegistration.Password = customerRegistrationDTO.Password;
                    customerRegistration.Image = customerRegistrationDTO.Image;
                    customerRegistration.CreatedBy = customerRegistrationDTO.CreatedBy;
                    customerRegistration.CreatedDate = System.DateTime.Now;
                    var obj = _customerRegistrationRepo.Insert(customerRegistration);

                    return MessageEnum.Success;

                }
                else
                {
                    return MessageEnum.Duplicate;
                }
            }
            catch
            {
                throw;
            }
        }

        public MessageEnum CustomerRegistrationUpdate(CustomerRegistrationDTO customerRegistrationDTO)
        {
            try
            {
                var updateCustomerRegistration = _dbContext.CustomerRegistrations.Where(x => x.CustomerRegistrationId != customerRegistrationDTO.CustomerRegistrationId && x.CustomerName == customerRegistrationDTO.CustomerName && x.Deleted == false).FirstOrDefault();
                if (updateCustomerRegistration == null)
                {
                    var a = _dbContext.CustomerRegistrations.Where(x => x.CustomerRegistrationId == customerRegistrationDTO.CustomerRegistrationId).FirstOrDefault();
                    if (a != null)
                    {
                        a.CustomerName = customerRegistrationDTO.CustomerName;
                        a.Address = customerRegistrationDTO.Address;
                        a.PrimaryPhone = customerRegistrationDTO.PrimaryPhone;
                        a.AlternatePhone = customerRegistrationDTO.AlternatePhone;
                        a.MailId = customerRegistrationDTO.MailId;
                        a.DateOfBirth = customerRegistrationDTO.DateOfBirth;
                        a.Password = customerRegistrationDTO.Password;
                        a.Image = customerRegistrationDTO.Image;
                        a.UpdatedBy = customerRegistrationDTO.CreatedBy;
                        a.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }

            }
            catch
            {
                throw;
            }
        }

        public MessageEnum DeleteCustomerRegistration(int CustomerRegistrationId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.CustomerRegistrations.Where(x => x.CustomerRegistrationId == CustomerRegistrationId).FirstOrDefault();
                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }

        public CustomerRegistration GetCustomerRegistrationById(int CustomerRegistrationId)
        {
            return _dbContext.CustomerRegistrations.Where(x => x.CustomerRegistrationId == CustomerRegistrationId && x.Deleted == false).SingleOrDefault();
        }

        public List<CustomerRegistration> GetCustomerRegistrationList()
        {
            try
            {
                return _dbContext.CustomerRegistrations.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
