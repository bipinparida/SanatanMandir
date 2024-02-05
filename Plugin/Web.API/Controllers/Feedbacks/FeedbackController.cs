using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.DTO.SanatanMandir.Temples;
using CloudVOffice.Services.Pandit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Feedbacks
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost]
        public IActionResult FeedbackCreate(FeedbackDTO feedbackDTO)
        {
            try
            {
                var a = _feedbackService.FeedbackCreate(feedbackDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult FeedbackList()
        {
            var a = _feedbackService.GetFeedbackList();
            return Ok(a);
        }
        [HttpGet("{feedbackId}")]
        public IActionResult SingleFeedbackListbyId(int feedbackId)
        {
            var a = _feedbackService.GetFeedbackById(feedbackId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult FeedbackUpdate(FeedbackDTO feedbackDTO)
        {
            try
            {
                var a = _feedbackService.FeedbackUpdate(feedbackDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet("{feedbackId}/{DeletedBy}")]
        public ActionResult DeleteTemple(int feedbackId, int DeletedBy)
        {
            var a = _feedbackService.DeleteFeedback(feedbackId, DeletedBy);
            return Ok(a);
        }
    }
}
