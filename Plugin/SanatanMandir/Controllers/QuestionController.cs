using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Services.Pandit;
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
    public class QuestionController : BasePluginController
    {
        private readonly IQuestionService _questionServiceService;
        public QuestionController(IQuestionService questionServiceService)
        {
            _questionServiceService = questionServiceService;
        }

        [HttpGet]
        public IActionResult QuestionCreate(int? QuestionId)
        {
            QuestionDTO questionDTO = new QuestionDTO();

            if (QuestionId != null)
            {

                Question d = _questionServiceService.GetQuestionById(int.Parse(QuestionId.ToString()));

                questionDTO.QuestionName = d.QuestionName;


            }

            return View("~/Plugins/SanatanMandir/Views/Question/QuestionCreate.cshtml", questionDTO);

        }

        [HttpPost]
        public IActionResult QuestionCreate(QuestionDTO questionDTO)
        {
            questionDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (questionDTO.QuestionId == null)
                {
                    var a = _questionServiceService.QuestionCreate(questionDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/Question/QuestionView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Question Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _questionServiceService.QuestionUpdate(questionDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/Question/QuestionView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Question Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/Question/QuestionCreate.cshtml", questionDTO);

        }

        public IActionResult QuestionView()
        {
            ViewBag.Questions = _questionServiceService.GetQuestionList();

            return View("~/Plugins/SanatanMandir/Views/Question/QuestionView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteQuestion(int QuestionId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _questionServiceService.DeleteQuestion(QuestionId, DeletedBy);
            return Redirect("/SanatanMandir/Question/QuestionView");
        }
    }
}
