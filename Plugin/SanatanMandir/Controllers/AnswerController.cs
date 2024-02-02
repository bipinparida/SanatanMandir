using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Services.LoactionMaster;
using CloudVOffice.Services.Pandit;
using CloudVOffice.Services.SanatanMandir.Temples;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class AnswerController : BasePluginController
    {

        private readonly IAnswerService _answerService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IQuestionService _questionServiceService;
        public AnswerController(IAnswerService answerService,
                                            IWebHostEnvironment hostingEnvironment,
                                            IQuestionService questionServiceService
                                            )
        {
            _answerService = answerService;
            _hostingEnvironment = hostingEnvironment;
            _questionServiceService = questionServiceService;
            

        }

        [HttpGet]
        public IActionResult AnswerCreate(int? AnswerId)
        {
            AnswerDTO answerDTO = new AnswerDTO();
            ViewBag.Questions = _questionServiceService.GetQuestionList();
            if (AnswerId != null)
            {

                Answer d = _answerService.GetAnswerById(int.Parse(AnswerId.ToString()));

                answerDTO.QuestionId = d.QuestionId;
                answerDTO.Answers = d.Answers;
               

            }

            return View("~/Plugins/SanatanMandir/Views/Answer/AnswerCreate.cshtml", answerDTO);

        }

        [HttpPost]
        public IActionResult AnswerCreate(AnswerDTO answerDTO)
        {
            answerDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (answerDTO.AnswerUp != null)
                {
                    FileInfo fileInfo = new FileInfo(answerDTO.AnswerUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/AnswerUpp");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    answerDTO.AnswerUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    answerDTO.Answers = uniqueFileName;
                }
                if (answerDTO.AnswerId == null)
                {
                    var a = _answerService.AnswerCreate(answerDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/Answer/AnswerView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Answer Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _answerService.AnswerUpdate(answerDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/Answer/AnswerView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Answer Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            ViewBag.Questions = _questionServiceService.GetQuestionList();
            return View("~/Plugins/SanatanMandir/Views/Answer/AnswerCreate.cshtml", answerDTO);

        }

        public IActionResult AnswerView()
        {
            ViewBag.Answerss = _answerService.GetAnswerList();

            return View("~/Plugins/SanatanMandir/Views/Answer/AnswerView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteAnswer(int AnswerId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _answerService.DeleteAnswer(AnswerId, DeletedBy);
            return Redirect("/SanatanMandir/Answer/AnswerView");
        }
        
    }
}
