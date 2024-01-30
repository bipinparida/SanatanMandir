using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanMandir.Temples;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanMandir.Temples;
using CloudVOffice.Services.LoactionMaster;
using CloudVOffice.Services.SanatanMandir.PoojaCategories;
using CloudVOffice.Services.SanatanMandir.Temples;
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
    public class TempleController : BasePluginController
    {
        private readonly ITempleService _templeService;
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IPoojaCategoryService _poojaCategoryService;
        public TempleController(ITempleService templeService, ICountryService countryService, IStateService stateService, ICityService cityService, IPoojaCategoryService poojaCategoryService)
        {
            _templeService = templeService;
            _countryService = countryService;
            _stateService = stateService;
            _cityService = cityService;
            _poojaCategoryService = poojaCategoryService;
        }

        [HttpGet]
        public IActionResult TempleCreate(int? TempleId)
        {
            TempleDTO templeDTO = new TempleDTO();
            ViewBag.Country = _countryService.GetCountryList();
            ViewBag.States = _stateService.GetStateList();
            ViewBag.City = _cityService.GetCityList();
            ViewBag.PoojaCategorys = _poojaCategoryService.GetPoojaCategoryList();

            if (TempleId != null)
            {

                Temple d = _templeService.GetTempleById(int.Parse(TempleId.ToString()));

                templeDTO.TempleName = d.TempleName;
                templeDTO.GodName = d.GodName;
                templeDTO.CountryId = d.CountryId;
                templeDTO.StateId = d.StateId;
                templeDTO.CityId = d.CityId;
                templeDTO.PoojaCategoryId = d.PoojaCategoryId;


            }

            return View("~/Plugins/SanatanMandir/Views/Temple/TempleCreate.cshtml", templeDTO);

        }

        [HttpPost]
        public IActionResult TempleCreate(TempleDTO templeDTO)
        {
            templeDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (templeDTO.TempleId == null)
                {
                    var a = _templeService.TempleCreate(templeDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/Temple/TempleView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Temple Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _templeService.TempleUpdate(templeDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/Temple/TempleView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Temple Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/Temple/TempleCreate.cshtml", templeDTO);

        }

        public IActionResult TempleView()
        {
            ViewBag.Temples = _templeService.GetTempleList();

            return View("~/Plugins/SanatanMandir/Views/Temple/TempleView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteTemple(int TempleId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _templeService.DeleteTemple(TempleId, DeletedBy);
            return Redirect("/SanatanMandir/Temple/TempleView");
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
