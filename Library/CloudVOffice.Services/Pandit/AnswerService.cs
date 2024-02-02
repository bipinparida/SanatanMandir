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
    public class AnswerService: IAnswerService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Answer> _answerRepo;
        public AnswerService(ApplicationDBContext dbContext, ISqlRepository<Answer> answerRepo)
        {
            _dbContext = dbContext;
            _answerRepo = answerRepo;
        }
        public MessageEnum AnswerCreate(AnswerDTO answerDTO)
        {

            try
            {
                var objcheck = _dbContext.Answers.SingleOrDefault(opt => opt.Deleted == false && opt.AnswerId == answerDTO.AnswerId);
                if (objcheck == null)
                {
                    Answer answer = new Answer();
                    answer.QuestionId = answerDTO.QuestionId;
                    answer.Answers = answerDTO.Answers;
                    answer.CreatedBy = answerDTO.CreatedBy;
                    answer.CreatedDate = System.DateTime.Now;
                    var obj = _answerRepo.Insert(answer);

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

        public MessageEnum AnswerUpdate(AnswerDTO answerDTO)
        {
            try
            {
                var updateAnswer = _dbContext.Answers.Where(x => x.AnswerId != answerDTO.AnswerId && x.Deleted == false).FirstOrDefault();
                if (updateAnswer == null)
                {
                    var a = _dbContext.Answers.Where(x => x.AnswerId == answerDTO.AnswerId).FirstOrDefault();
                    if (a != null)
                    {
                        a.QuestionId = answerDTO.QuestionId;
                        a.Answers = answerDTO.Answers;
                        a.UpdatedBy = answerDTO.CreatedBy;
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

        public MessageEnum DeleteAnswer(int AnswerId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Answers.Where(x => x.AnswerId == AnswerId).FirstOrDefault();
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

        public Answer GetAnswerById(int AnswerId)
        {
            return _dbContext.Answers.Where(x => x.AnswerId == AnswerId && x.Deleted == false).SingleOrDefault();
        }

        public List<Answer> GetAnswerList()
        {
            try
            {
                return _dbContext.Answers.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
