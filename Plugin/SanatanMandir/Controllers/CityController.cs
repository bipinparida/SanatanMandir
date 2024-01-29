using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Data.DTO.LocationMaster;
using CloudVOffice.Services.LoactionMaster;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Hangfire.States;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class CityController : BasePluginController
    {
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        public CityController(IStateService stateService, ICountryService countryService, ICityService cityService)
        {
            _stateService = stateService;
            _countryService = countryService;
            _cityService = cityService;
        }
        [HttpGet]
        public IActionResult CityCreate(int? CityId)
        {
            CityDTO cityDTO = new CityDTO();


            ViewBag.Country = _countryService.GetCountryList();
            ViewBag.States = _stateService.GetStateList();
            if (CityId != null)
            {

                City d = _cityService.GetCityByCityId(int.Parse(CityId.ToString()));

                cityDTO.CityName = d.CityName;
                cityDTO.CountryId = d.CountryId;
                cityDTO.StateId = d.StateId;
            }

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/CityCreate.cshtml", cityDTO);
        }

        [HttpPost]
        public IActionResult CityCreate(CityDTO cityDTO)
        {
            cityDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (cityDTO.CityId == null)
                {
                    var a = _cityService.CityCreate(cityDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/City/CityView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "City Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _cityService.CityUpdate(cityDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/City/CityView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "City Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            ViewBag.Country = _countryService.GetCountryList();
            ViewBag.State = _stateService.GetStateList();
            return View("~/Plugins/SanatanMandir/Views/LocationMaster/CityCreate.cshtml", cityDTO);

        }

        public IActionResult CityView()
        {
            ViewBag.City = _cityService.GetCityList();

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/CityView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteCity(int CityId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _cityService.CityDelete(CityId, DeletedBy);
            return Redirect("/SanatanMandir/City/CityView");
        }

        public JsonResult GetCityByStateId(int StateId)
        {
            return Json(_cityService.GetCityByStateId(StateId));
        }
    }
}
