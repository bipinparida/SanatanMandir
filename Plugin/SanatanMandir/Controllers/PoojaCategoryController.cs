using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Services.SanatanMandir.PoojaCategories;
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
    public class PoojaCategoryController : BasePluginController
    {
        private readonly IPoojaCategoryService _poojaCategoryService;
        public PoojaCategoryController(IPoojaCategoryService poojaCategoryService)
        {
            _poojaCategoryService = poojaCategoryService;
        }

        [HttpGet]
        public IActionResult PoojaCategoryCreate(int? PoojaCategoryId)
        {
            PoojaCategoryDTO poojaCategoryDTO = new PoojaCategoryDTO();

            if (PoojaCategoryId != null)
            {

                PoojaCategory d = _poojaCategoryService.GetPoojaCategoryById(int.Parse(PoojaCategoryId.ToString()));

                poojaCategoryDTO.PoojaCategoryName = d.PoojaCategoryName;
               

            }

            return View("~/Plugins/SanatanMandir/Views/PoojaCategory/PoojaCategoryCreate.cshtml", poojaCategoryDTO);

        }

        [HttpPost]
        public IActionResult PoojaCategoryCreate(PoojaCategoryDTO poojaCategoryDTO)
        {
            poojaCategoryDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (poojaCategoryDTO.PoojaCategoryId == null)
                {
                    var a = _poojaCategoryService.PoojaCategoryCreate(poojaCategoryDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/PoojaCategory/PoojaCategoryView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "PoojaCategory Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _poojaCategoryService.PoojaCategoryUpdate(poojaCategoryDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/PoojaCategory/PoojaCategoryView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "PoojaCategory Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/PoojaCategory/PoojaCategoryCreate.cshtml", poojaCategoryDTO);

        }

        public IActionResult PoojaCategoryView()
        {
            ViewBag.PoojaCategorys = _poojaCategoryService.GetPoojaCategoryList();

            return View("~/Plugins/SanatanMandir/Views/PoojaCategory/PoojaCategoryView.cshtml");
        }

        [HttpGet]
        public IActionResult DeletePoojaCategory(int PoojaCategoryId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _poojaCategoryService.DeletePoojaCategory(PoojaCategoryId, DeletedBy);
            return Redirect("/SanatanMandir/PoojaCategory/PoojaCategoryView");
        }
    }
}
