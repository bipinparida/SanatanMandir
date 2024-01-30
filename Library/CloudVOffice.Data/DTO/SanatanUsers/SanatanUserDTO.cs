using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.SanatanUsers
{
    public class SanatanUserDTO
    {
        public int? SanatanUserId { get; set; }
        public string SanatanUserName { get; set; }

        public Int64 CreatedBy { get; set; }
    }
}
