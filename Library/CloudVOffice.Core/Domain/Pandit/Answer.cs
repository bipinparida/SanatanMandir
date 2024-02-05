using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Pandit
{
    public class Answer : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 AnswerId { get; set; }
        public Int64 QuestionId { get; set; }
        public Int64 PanditRegistrationId { get; set; }
        public string Answers { get; set; }

        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
