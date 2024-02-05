using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Pandit
{
    public class FeedbackDTO
    {
        public Int64? FeedbackId { get; set; }
        public string? FeedbackName { get; set; }
        public Int64 PanditRegistrationId { get; set; }
        public Int64 CustomerRegistrationId { get; set; }

        public Int64 CreatedBy { get; set; }
    }
}
