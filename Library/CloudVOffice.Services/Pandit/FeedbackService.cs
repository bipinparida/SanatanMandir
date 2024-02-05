using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Pandit
{
    public class FeedbackService: IFeedbackService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Feedback> _feedbackRepo;
        public FeedbackService(ApplicationDBContext dbContext, ISqlRepository<Feedback> feedbackRepo)
        {
            _dbContext = dbContext;
            _feedbackRepo = feedbackRepo;
        }
        public MessageEnum FeedbackCreate(FeedbackDTO feedbackDTO)
        {

            try
            {
                var objcheck = _dbContext.Feedbacks.SingleOrDefault(opt => opt.Deleted == false && opt.FeedbackName == feedbackDTO.FeedbackName);
                if (objcheck == null)
                {
                    Feedback feedback = new Feedback();
                    feedback.FeedbackName = feedbackDTO.FeedbackName;
                    feedback.PanditRegistrationId = feedbackDTO.PanditRegistrationId;
                    feedback.CustomerRegistrationId = feedbackDTO.CustomerRegistrationId;
                    feedback.CreatedBy = feedbackDTO.CreatedBy;
                    feedback.CreatedDate = System.DateTime.Now;
                    var obj = _feedbackRepo.Insert(feedback);

                    return MessageEnum.Success;

                }
                else
                {
                    return MessageEnum.Duplicate;
                }
            }
            catch
            {
                throw;
            }
        }

        public MessageEnum FeedbackUpdate(FeedbackDTO feedbackDTO)
        {
            try
            {
                var updateFeedback = _dbContext.Feedbacks.Where(x => x.FeedbackId != feedbackDTO.FeedbackId && x.FeedbackName == feedbackDTO.FeedbackName && x.Deleted == false).FirstOrDefault();
                if (updateFeedback == null)
                {
                    var a = _dbContext.Feedbacks.Where(x => x.FeedbackId == feedbackDTO.FeedbackId).FirstOrDefault();
                    if (a != null)
                    {
                        a.FeedbackName = feedbackDTO.FeedbackName;
                        a.PanditRegistrationId = feedbackDTO.PanditRegistrationId;
                        a.CustomerRegistrationId = feedbackDTO.CustomerRegistrationId;
                        a.UpdatedBy = feedbackDTO.CreatedBy;
                        a.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }

            }
            catch
            {
                throw;
            }
        }

        public MessageEnum DeleteFeedback(int FeedbackId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Feedbacks.Where(x => x.FeedbackId == FeedbackId).FirstOrDefault();
                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }

        public Feedback GetFeedbackById(int FeedbackId)
        {
            return _dbContext.Feedbacks.Where(x => x.FeedbackId == FeedbackId && x.Deleted == false).SingleOrDefault();
        }

        public List<Feedback> GetFeedbackList()
        {
            try
            {
                return _dbContext.Feedbacks.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }

    }
}
