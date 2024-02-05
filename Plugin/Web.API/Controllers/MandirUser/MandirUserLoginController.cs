using CloudVOffice.Core.Domain.Customer;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.SanatanUsers;
using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerRegistration = CloudVOffice.Core.Domain.Customer.CustomerRegistration;

namespace Web.API.Controllers.MandirUser
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MandirUserLoginController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public MandirUserLoginController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("{UserMobileNumber}/{Password}")]
        public IActionResult UserLogin(string UserMobileNumber, string Password)
        {
            var pandit = _dbContext.PanditRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);
            var customer = _dbContext.CustomerRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);

            if (pandit == null && customer == null)
            {
                return BadRequest("UserMobileNumber is incorrect or Number not in use");
            }

            else if (pandit != null)
            {
                if (pandit.IsApprove == true)
                {
                    if (pandit.Password == Password)
                    {
                        return Ok(new { pandit = pandit });
                    }
                    else
                    {
                        return BadRequest("Mobile Number is correct but the Password is wrong");
                    }
                }
                else
                {
                    return BadRequest("Pandit is not approved");
                }
            }

            else if (customer != null)
            {
                if (customer.Password == Password)
                {
                    return Ok(new { customer = customer });
                }
                else
                {
                    return BadRequest("Mobile Number is correct but the Password is wrong");
                }
            }

            else
            {
                return BadRequest("Mobile Number is correct but the Password is wrong");
            }
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var pandit = _dbContext.PanditRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);
            var customer = _dbContext.CustomerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);

            if (pandit == null && customer == null)
            {
                return BadRequest("User not found");
            }

            var user = (pandit != null) ? (object)pandit : customer;

            if (user is PanditRegistration && ((PanditRegistration)user).Password != changePasswordDTO.OldPassword)
            {
                return BadRequest("Old password is incorrect");
            }
            else if (user is CustomerRegistration && ((CustomerRegistration)user).Password != changePasswordDTO.OldPassword)
            {
                return BadRequest("Old password is incorrect");
            }

            if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
            {
                return BadRequest("New password and retype password do not match");
            }

            if (user is PanditRegistration)
            {
                var panditToUpdate = (PanditRegistration)user;
                panditToUpdate.Password = changePasswordDTO.NewPassword;
               // panditToUpdate.FirstLogin = true;
            }
            else if (user is CustomerRegistration)
            {
                var customerToUpdate = (CustomerRegistration)user;
                customerToUpdate.Password = changePasswordDTO.NewPassword;
            }

            _dbContext.SaveChanges();

            return Ok("Password changed successfully");
        }
    }
}
