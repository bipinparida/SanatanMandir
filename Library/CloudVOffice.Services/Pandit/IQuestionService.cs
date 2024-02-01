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
    public interface IQuestionService
    {
        public MessageEnum QuestionCreate(QuestionDTO questionDTO);
        public MessageEnum QuestionUpdate(QuestionDTO questionDTO);
        public MessageEnum DeleteQuestion(int QuestionId, Int64 DeletedBy);
        public List<Question> GetQuestionList();
        public Question GetQuestionById(int QuestionId);
    }
}
