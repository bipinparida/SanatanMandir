using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanUsers;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanUsers;
using CloudVOffice.Services.SanatanMandir.PoojaCategories;
using CloudVOffice.Services.SanatanUsers;
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
    public class SanatanUserController : BasePluginController
    {
        private readonly ISanatanUserService _sanatanUserService;
        public SanatanUserController(ISanatanUserService sanatanUserService)
        {
            _sanatanUserService = sanatanUserService;
        }

        [HttpGet]
        public IActionResult SanatanUserCreate(int? SanatanUserId)
        {
            SanatanUserDTO sanatanUserDTO = new SanatanUserDTO();

            if (SanatanUserId != null)
            {

                SanatanUser d = _sanatanUserService.GetSanatanUserById(int.Parse(SanatanUserId.ToString()));

                sanatanUserDTO.SanatanUserName = d.SanatanUserName;


            }

            return View("~/Plugins/SanatanMandir/Views/SanatanUser/SanatanUserCreate.cshtml", sanatanUserDTO);

        }

        [HttpPost]
        public IActionResult SanatanUserCreate(SanatanUserDTO sanatanUserDTO)
        {
            sanatanUserDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (sanatanUserDTO.SanatanUserId == null)
                {
                    var a = _sanatanUserService.SanatanUserCreate(sanatanUserDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/SanatanUser/SanatanUserView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "SanatanUser Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _sanatanUserService.SanatanUserUpdate(sanatanUserDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/SanatanUser/SanatanUserView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "SanatanUser Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/SanatanUser/SanatanUserCreate.cshtml", sanatanUserDTO);

        }

        public IActionResult SanatanUserView()
        {
            ViewBag.SanatanUsers = _sanatanUserService.GetSanatanUserList();

            return View("~/Plugins/SanatanMandir/Views/SanatanUser/SanatanUserView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteSanatanUser(int SanatanUserId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _sanatanUserService.DeleteSanatanUser(SanatanUserId, DeletedBy);
            return Redirect("/SanatanMandir/SanatanUser/SanatanUserView");
        }
    }
}
