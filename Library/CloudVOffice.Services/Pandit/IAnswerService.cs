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
    public interface IAnswerService
    {
        public MessageEnum AnswerCreate(AnswerDTO answerDTO);
        public MessageEnum AnswerUpdate(AnswerDTO answerDTO);
        public MessageEnum DeleteAnswer(int AnswerId, Int64 DeletedBy);
        public List<Answer> GetAnswerList();
        public Answer GetAnswerById(int AnswerId);
    }
}
