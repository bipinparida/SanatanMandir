using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Pandit
{
    public class QuestionDTO
    {
        public Int64? QuestionId { get; set; }
        public string QuestionName { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
