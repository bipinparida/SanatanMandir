﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Logging
{
    public class ErrorLogDTO
    {
        public DateTime LogedOn { get; set; }
        public Int64? UserId { get; set; }
        public int StatusCode { get; set; }
        public string? AreaName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string StackTrace { get; set; }
        public string ErrorMessage { get; set; }
    }
}
