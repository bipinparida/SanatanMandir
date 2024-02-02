using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Pandit
{
    public class AnswerDTO
    {
        public Int64? AnswerId { get; set; }
        public Int64 QuestionId { get; set; }
        public string? Answers { get; set; }
        public Int64 CreatedBy { get; set; }
        public IFormFile? AnswerUp { get; set; }
    }
}
