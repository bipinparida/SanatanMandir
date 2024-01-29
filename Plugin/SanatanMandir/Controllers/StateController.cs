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
    public class StateController : BasePluginController
    {
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        public StateController(IStateService stateService, ICountryService countryService)
        {
            _stateService = stateService;
            _countryService = countryService;
        }
        [HttpGet]
        public IActionResult StateCreate(int? StateId)
        {
            StateDTO stateDTO = new StateDTO();


            ViewBag.Country = _countryService.GetCountryList();

            if (StateId != null)
            {

                State d = _stateService.GetStateByStateId(int.Parse(StateId.ToString()));

                stateDTO.StateName = d.StateName;
                stateDTO.CountryId = d.CountryId;


            }

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/StateCreate.cshtml", stateDTO);

        }

        [HttpPost]
        public IActionResult StateCreate(StateDTO stateDTO)
        {
            stateDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (stateDTO.StateId == null)
                {
                    var a = _stateService.StateCreate(stateDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/State/StateView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "State Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _stateService.StateUpdate(stateDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/State/StateView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "State Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            ViewBag.Country = _countryService.GetCountryList();
            return View("~/Plugins/SanatanMandir/Views/LocationMaster/StateCreate.cshtml", stateDTO);

        }
        public IActionResult StateView()
        {
            ViewBag.States = _stateService.GetStateList();

            return View("~/Plugins/SanatanMandir/Views/LocationMaster/StateView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteState(int StateId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _stateService.DeleteState(StateId, DeletedBy);
            return Redirect("/SanatanMandir/State/StateView");
        }

        public JsonResult GetStateByCountryId(int CountryId)
        {
            return Json(_stateService.GetStateByCountryId(CountryId));
        }
    }
}
