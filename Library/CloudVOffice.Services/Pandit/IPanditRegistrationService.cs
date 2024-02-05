using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.DTO.SanatanUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Pandit
{
    public interface IPanditRegistrationService
    {
        public MessageEnum PanditRegistrationCreate(PanditRegistrationDTO panditRegistrationDTO);
        public MessageEnum PanditRegistrationUpdate(PanditRegistrationDTO panditRegistrationDTO);
        public List<PanditRegistration> GetPanditRegistrationList();
        public PanditRegistration GetPanditRegistrationById(int PanditRegistrationId);
        public MessageEnum DeletePanditRegistration(int PanditRegistrationId, Int64 DeletedBy);

        public MessageEnum ApprovePanditRegistration(int PanditRegistrationId);
        public MessageEnum RejectPanditRegistration(int PanditRegistrationId);
        public MessageEnum PanditRegistrationMessageUpdate(PanditRegistrationDTO panditRegistrationDTO);

    }
}
