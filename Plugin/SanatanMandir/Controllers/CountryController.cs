using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Data.DTO.LocationMaster;
using CloudVOffice.Services.LoactionMaster;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class CountryController : BasePluginController
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult CountryCreate(int? CountryId)
        {
            CountryDTO countryDTO = new CountryDTO();

            if (CountryId != null)
            {

                Country d = _countryService.GetCountryById(int.Parse(CountryId.ToString()));

                countryDTO.CountryName = d.CountryName;
                countryDTO.CountryCode = d.CountryCode;


            }

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/CountryCreate.cshtml", countryDTO);

        }

        [HttpPost]
        public IActionResult CountryCreate(CountryDTO countryDTO)
        {
            countryDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (countryDTO.CountryId == null)
                {
                    var a = _countryService.CountryCreate(countryDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/Country/CountryView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Country Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _countryService.CountryUpdate(countryDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/Country/CountryView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Country Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/CountryCreate.cshtml", countryDTO);

        }

        public IActionResult CountryView()
        {
            ViewBag.Countrys = _countryService.GetCountryList();

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/CountryView.cshtml");
        }

        [HttpGet]
        public IActionResult CountryDelete(int CountryId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _countryService.DeleteCountry(CountryId, DeletedBy);
            return Redirect("/SanatanMandir/Country/CountryView");
        }
    }
}
