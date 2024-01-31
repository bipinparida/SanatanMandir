using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Pandit
{
    public class PanditRegistrationDTO
    {
        public Int64? PanditRegistrationId { get; set; }
        public Int64 TempleId { get; set; }
        public string? PanditName { get; set; }
        public string? Address { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? MailId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public bool? IsApprove { get; set; }

        public Int64 CreatedBy { get; set; }
    }
}
