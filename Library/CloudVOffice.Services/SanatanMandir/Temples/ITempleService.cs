using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanMandir.Temples;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanMandir.Temples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.SanatanMandir.Temples
{
    public interface ITempleService
    {
        public MessageEnum TempleCreate(TempleDTO templeDTO);
        public MessageEnum TempleUpdate(TempleDTO templeDTO);
        public MessageEnum DeleteTemple(int TempleId, Int64 DeletedBy);
        public List<Temple> GetTempleList();
        public Temple GetTempleById(int TempleId);
       

    }
}
