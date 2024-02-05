using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Pandit
{
    public interface IFeedbackService
    {
        public MessageEnum FeedbackCreate(FeedbackDTO feedbackDTO);
        public MessageEnum FeedbackUpdate(FeedbackDTO feedbackDTO);
        public MessageEnum DeleteFeedback(int FeedbackId, Int64 DeletedBy);
        public List<Feedback> GetFeedbackList();
        public Feedback GetFeedbackById(int FeedbackId);
    }
}
