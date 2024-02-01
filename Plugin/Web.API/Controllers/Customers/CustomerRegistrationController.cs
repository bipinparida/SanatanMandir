using CloudVOffice.Data.DTO.Customer;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Services.Customer;
using CloudVOffice.Services.Pandit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Customers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerRegistrationController : Controller
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CustomerRegistrationController(ICustomerRegistrationService customerRegistrationService,
                                            IWebHostEnvironment hostingEnvironment
                                           )
        {
            _customerRegistrationService = customerRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost]
        public IActionResult CustomerSigninCreate([FromForm] CustomerRegistrationDTO customerRegistrationDTO)
        {
            try
            {

                if (customerRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(customerRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(customerRegistrationDTO.ImageUp.FileName);

                    string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\CustomerRegistrationImage\" + customerRegistrationDTO.CreatedBy.ToString());
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        customerRegistrationDTO.ImageUp.CopyTo(stream);
                    }

                    customerRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    customerRegistrationDTO.Image = filename;

                }


                var a = _customerRegistrationService.CustomerRegistrationCreate(customerRegistrationDTO);


                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult CustomerSigninList()
        {
            var a = _customerRegistrationService.GetCustomerRegistrationList();
            return Ok(a);
        }

        [HttpPost]
        public IActionResult CustomerSigninUpdate([FromForm] CustomerRegistrationDTO customerRegistrationDTO)
        {
            try
            {

                if (customerRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(customerRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(customerRegistrationDTO.ImageUp.FileName);

                    string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\CustomerRegistrationImage\" + customerRegistrationDTO.CreatedBy.ToString());
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        customerRegistrationDTO.ImageUp.CopyTo(stream);
                    }

                    customerRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    customerRegistrationDTO.Image = filename;

                }


                var a = _customerRegistrationService.CustomerRegistrationUpdate(customerRegistrationDTO);


                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{CustomerRegistrationId}")]
        public IActionResult CustomerSignListbyId(int CustomerRegistrationId)
        {
            var a = _customerRegistrationService.GetCustomerRegistrationById(CustomerRegistrationId);
            return Ok(a);
        }
    }
}
