using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Services.Pandit;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class FeedbackController : BasePluginController
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult FeedbackCreate(int? FeedbackId)
        {
            FeedbackDTO feedbackDTO = new FeedbackDTO();

            if (FeedbackId != null)
            {

                Feedback d = _feedbackService.GetFeedbackById(int.Parse(FeedbackId.ToString()));

                feedbackDTO.FeedbackName = d.FeedbackName;
                feedbackDTO.PanditRegistrationId = d.PanditRegistrationId;
                feedbackDTO.CustomerRegistrationId= d.CustomerRegistrationId;


            }

            return View("~/Plugins/SanatanMandir/Views/Feedback/FeedbackCreate.cshtml", feedbackDTO);

        }

        [HttpPost]
        public IActionResult FeedbackCreate(FeedbackDTO feedbackDTO)
        {
            feedbackDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (feedbackDTO.FeedbackId == null)
                {
                    var a = _feedbackService.FeedbackCreate(feedbackDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SanatanMandir/Feedback/FeedbackView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Feedback Already Exists");

                    }
                    else
                    {

                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");

                    }
                }
                else
                {
                    var a = _feedbackService.FeedbackUpdate(feedbackDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SanatanMandir/Feedback/FeedbackView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Feedback Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/SanatanMandir/Views/Feedback/FeedbackCreate.cshtml", feedbackDTO);

        }

        public IActionResult FeedbackView()
        {
            ViewBag.Feedbacks = _feedbackService.GetFeedbackList();

            return View("~/Plugins/SanatanMandir/Views/Feedback/FeedbackView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteFeedback(int FeedbackId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _feedbackService.DeleteFeedback(FeedbackId, DeletedBy);
            return Redirect("/SanatanMandir/Feedback/FeedbackView");
        }
    }
}
