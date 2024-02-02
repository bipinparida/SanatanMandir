using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.DTO.SanatanUsers;
using CloudVOffice.Services.Pandit;
using CloudVOffice.Services.SanatanUsers;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Services.SanatanMandir.Temples;
using CloudVOffice.Services.LoactionMaster;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class PanditRegistrationController : BasePluginController
    {
        private readonly IPanditRegistrationService _panditRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ITempleService _templeService;
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        public PanditRegistrationController(IPanditRegistrationService panditRegistrationService,
                                            IWebHostEnvironment hostingEnvironment,
                                            ITempleService templeService,
                                            ICountryService countryService,
                                            IStateService stateService,
                                            ICityService cityService)
        {
            _panditRegistrationService = panditRegistrationService;
            _hostingEnvironment = hostingEnvironment;
            _templeService= templeService;
            _countryService = countryService;
            _stateService = stateService;
            _cityService = cityService;
            
        }

        [HttpGet]
        public IActionResult PanditRegistrationCreate(int? PanditRegistrationId)
        {
            PanditRegistrationDTO panditRegistrationDTO = new PanditRegistrationDTO();
            ViewBag.Temples = _templeService.GetTempleList();
            ViewBag.Country = _countryService.GetCountryList();
            ViewBag.States = _stateService.GetStateList();
            ViewBag.City = _cityService.GetCityList();
            if (PanditRegistrationId != null)
            {

                PanditRegistration d = _panditRegistrationService.GetPanditRegistrationById(int.Parse(PanditRegistrationId.ToString()));

                panditRegistrationDTO.PanditName = d.PanditName;
                panditRegistrationDTO.CountryId= d.CountryId;
                panditRegistrationDTO.StateId=d.StateId;
                panditRegistrationDTO.CityId= d.CityId;
                panditRegistrationDTO.Experiences = d.Experiences;
                panditRegistrationDTO.ExpertiseOnPuja = d.ExpertiseOnPuja;
                panditRegistrationDTO.Religion=d.Religion;
                panditRegistrationDTO.MotherTongue=d.MotherTongue;
                panditRegistrationDTO.Caste=d.Caste;
                panditRegistrationDTO.Gothram=d.Gothram;
                panditRegistrationDTO.AadharCard=d.AadharCard;
                panditRegistrationDTO.Qualification=d.Qualification;
                panditRegistrationDTO.TempleId = d.TempleId;
                panditRegistrationDTO.Address = d.Address;
                panditRegistrationDTO.PrimaryPhone = d.PrimaryPhone;
                panditRegistrationDTO.AlternatePhone = d.AlternatePhone;
                panditRegistrationDTO.MailId = d.MailId;
                panditRegistrationDTO.DateOfBirth = d.DateOfBirth;
                panditRegistrationDTO.Password = d.Password;
                panditRegistrationDTO.Image = d.Image;
                panditRegistrationDTO.IsApprove = d.IsApprove;

            }

            return View("~/Plugins/SanatanMandir/Views/PanditRegistration/PanditRegistrationCreate.cshtml", panditRegistrationDTO);

        }

        [HttpPost]
        public IActionResult PanditRegistrationCreate(PanditRegistrationDTO panditRegistrationDTO)
        {
            panditRegistrationDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (panditRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(panditRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/PanditRegistrationImage");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    panditRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    panditRegistrationDTO.Image = uniqueFileName;
                }
                if (panditRegistrationDTO.PanditRegistrationId == null)
                {
                    var a = _panditRegistrationService.PanditRegistrationCreate(panditRegistrationDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/PanditRegistration/PanditRegistrationView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "PanditRegistration Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _panditRegistrationService.PanditRegistrationUpdate(panditRegistrationDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/PanditRegistration/PanditRegistrationView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "PanditRegistration Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/PanditRegistration/PanditRegistrationCreate.cshtml", panditRegistrationDTO);

        }

        public IActionResult PanditRegistrationView()
        {
            ViewBag.PanditRegistrations = _panditRegistrationService.GetPanditRegistrationList();

            return View("~/Plugins/SanatanMandir/Views/PanditRegistration/PanditRegistrationView.cshtml");
        }

        [HttpGet]
        public IActionResult DeletePanditRegistration(int PanditRegistrationId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _panditRegistrationService.DeletePanditRegistration(PanditRegistrationId, DeletedBy);
            return Redirect("/SanatanMandir/PanditRegistration/PanditRegistrationView");
        }
        public JsonResult GetStateByCountryId(int CountryId)
        {
            return Json(_stateService.GetStateByCountryId(CountryId));
        }
        public JsonResult GetCityByStateId(int StateId)
        {
            return Json(_cityService.GetCityByStateId(StateId));
        }
    }
}
