using CloudVOffice.Data.DTO.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Logging
{
    public interface IErrorLogService
    {
        public void LogError(ErrorLogDTO errorLog);
    }
}
