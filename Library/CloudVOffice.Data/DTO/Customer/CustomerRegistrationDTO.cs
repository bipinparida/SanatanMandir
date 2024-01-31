using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Customer
{
    public class CustomerRegistrationDTO
    {
        public Int64? CustomerRegistrationId { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? MailId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageUp { get; set; }

        public Int64 CreatedBy { get; set; }
    }
}
