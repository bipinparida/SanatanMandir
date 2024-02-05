using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Customer;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Customer;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Services.Customer;
using CloudVOffice.Services.Pandit;
using CloudVOffice.Services.SanatanMandir.Temples;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class CustomerRegistrationController : BasePluginController
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
       
        public CustomerRegistrationController(ICustomerRegistrationService customerRegistrationService, IWebHostEnvironment hostingEnvironment)
        {
            _customerRegistrationService = customerRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult CustomerRegistrationCreate(int? CustomerRegistrationId)
        {
            CustomerRegistrationDTO customerRegistrationDTO = new CustomerRegistrationDTO();
            
            if (CustomerRegistrationId != null)
            {

                CustomerRegistration d = _customerRegistrationService.GetCustomerRegistrationById(int.Parse(CustomerRegistrationId.ToString()));

                customerRegistrationDTO.CustomerName = d.CustomerName;
                customerRegistrationDTO.Address = d.Address;
                customerRegistrationDTO.PrimaryPhone = d.PrimaryPhone;
                customerRegistrationDTO.AlternatePhone = d.AlternatePhone;
                customerRegistrationDTO.MailId = d.MailId;
                customerRegistrationDTO.DateOfBirth = d.DateOfBirth;
                customerRegistrationDTO.Password = d.Password;
                customerRegistrationDTO.Image = d.Image;

            }

            return View("~/Plugins/SanatanMandir/Views/CustomerRegistration/CustomerRegistrationCreate.cshtml", customerRegistrationDTO);

        }

        [HttpPost]
        public IActionResult CustomerRegistrationCreate(CustomerRegistrationDTO customerRegistrationDTO)
        {
            customerRegistrationDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (customerRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(customerRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/CustomerRegistrationImage");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    customerRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    customerRegistrationDTO.Image = uniqueFileName;
                }
                if (customerRegistrationDTO.CustomerRegistrationId == null)
                {
                    var a = _customerRegistrationService.CustomerRegistrationCreate(customerRegistrationDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/CustomerRegistration/CustomerRegistrationView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Customer Mobile Number Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _customerRegistrationService.CustomerRegistrationUpdate(customerRegistrationDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/CustomerRegistration/CustomerRegistrationView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "CustomerRegistration Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/CustomerRegistration/CustomerRegistrationCreate.cshtml", customerRegistrationDTO);

        }

        public IActionResult CustomerRegistrationView()
        {
            ViewBag.CustomerRegistrations = _customerRegistrationService.GetCustomerRegistrationList();

            return View("~/Plugins/SanatanMandir/Views/CustomerRegistration/CustomerRegistrationView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteCustomerRegistration(int CustomerRegistrationId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _customerRegistrationService.DeleteCustomerRegistration(CustomerRegistrationId, DeletedBy);
            return Redirect("/SanatanMandir/CustomerRegistration/CustomerRegistrationView");
        }
    }
}
