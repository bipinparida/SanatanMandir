using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanUsers;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.SanatanUsers
{
    public interface ISanatanUserService
    {
        public MessageEnum SanatanUserCreate(SanatanUserDTO sanatanUserDTO);
        public MessageEnum SanatanUserUpdate(SanatanUserDTO sanatanUserDTO);
        public MessageEnum DeleteSanatanUser(int SanatanUserId, Int64 DeletedBy);
        public List<SanatanUser> GetSanatanUserList();
        public SanatanUser GetSanatanUserById(int SanatanUserId);
    }
}
