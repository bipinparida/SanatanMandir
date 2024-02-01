using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Pandit
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Question> _questionRepo;
        public QuestionService(ApplicationDBContext dbContext, ISqlRepository<Question> questionRepo)
        {
            _dbContext = dbContext;
            _questionRepo = questionRepo;
        }
        public MessageEnum QuestionCreate(QuestionDTO questionDTO)
        {

            try
            {
                var objcheck = _dbContext.Questions.SingleOrDefault(opt => opt.Deleted == false && opt.QuestionName == questionDTO.QuestionName);
                if (objcheck == null)
                {
                    Question question = new Question();
                    question.QuestionName = questionDTO.QuestionName;
                    question.CreatedBy = questionDTO.CreatedBy;
                    question.CreatedDate = System.DateTime.Now;
                    var obj = _questionRepo.Insert(question);

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

        public MessageEnum QuestionUpdate(QuestionDTO questionDTO)
        {
            try
            {
                var updateQuestion = _dbContext.Questions.Where(x => x.QuestionId != questionDTO.QuestionId && x.QuestionName == questionDTO.QuestionName && x.Deleted == false).FirstOrDefault();
                if (updateQuestion == null)
                {
                    var a = _dbContext.Questions.Where(x => x.QuestionId == questionDTO.QuestionId).FirstOrDefault();
                    if (a != null)
                    {
                        a.QuestionName = questionDTO.QuestionName;
                        a.UpdatedBy = questionDTO.CreatedBy;
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

        public MessageEnum DeleteQuestion(int QuestionId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Questions.Where(x => x.QuestionId == QuestionId).FirstOrDefault();
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

        public Question GetQuestionById(int QuestionId)
        {
            return _dbContext.Questions.Where(x => x.QuestionId == QuestionId && x.Deleted == false).SingleOrDefault();
        }

        public List<Question> GetQuestionList()
        {
            try
            {
                return _dbContext.Questions.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
