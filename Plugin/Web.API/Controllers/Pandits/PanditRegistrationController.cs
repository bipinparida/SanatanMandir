using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Services.Pandit;
using CloudVOffice.Services.SanatanMandir.Temples;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Pandits
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PanditRegistrationController : Controller
    {
        private readonly IPanditRegistrationService _panditRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PanditRegistrationController(IPanditRegistrationService panditRegistrationService, 
                                            IWebHostEnvironment hostingEnvironment
                                           )
        {
            _panditRegistrationService = panditRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult PanditSigninCreate([FromForm] PanditRegistrationDTO panditRegistrationDTO)
        {
            try
            {

                if (panditRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(panditRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(panditRegistrationDTO.ImageUp.FileName);

                    string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\PanditRegistrationImage\" + panditRegistrationDTO.CreatedBy.ToString());
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        panditRegistrationDTO.ImageUp.CopyTo(stream);
                    }

                    panditRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    panditRegistrationDTO.Image = filename;

                }


                var a = _panditRegistrationService.PanditRegistrationCreate(panditRegistrationDTO);


                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult PanditSigninList()
        {
            var a = _panditRegistrationService.GetPanditRegistrationList();
            return Ok(a);
        }

        [HttpPost]
        public IActionResult PanditSigninUpdate([FromForm] PanditRegistrationDTO panditRegistrationDTO)
        {
            try
            {

                if (panditRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(panditRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(panditRegistrationDTO.ImageUp.FileName);

                    string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\PanditRegistrationImage\" + panditRegistrationDTO.CreatedBy.ToString());
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        panditRegistrationDTO.ImageUp.CopyTo(stream);
                    }

                    panditRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    panditRegistrationDTO.Image = filename;

                }


                var a = _panditRegistrationService.PanditRegistrationUpdate(panditRegistrationDTO);


                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{PanditRegistrationId}")]
        public IActionResult PanditSignListbyId(int PanditRegistrationId)
        {
            var a = _panditRegistrationService.GetPanditRegistrationById(PanditRegistrationId);
            return Ok(a);
        }
    }
}
