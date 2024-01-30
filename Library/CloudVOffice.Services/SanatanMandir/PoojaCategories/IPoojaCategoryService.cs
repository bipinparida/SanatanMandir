using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.LocationMaster;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.SanatanMandir.PoojaCategories
{
    public interface IPoojaCategoryService
    {
        public MessageEnum PoojaCategoryCreate(PoojaCategoryDTO poojaCategoryDTO);
        public MessageEnum PoojaCategoryUpdate(PoojaCategoryDTO poojaCategoryDTO);
        public MessageEnum DeletePoojaCategory(int PoojaCategoryId, Int64 DeletedBy);
        public List<PoojaCategory> GetPoojaCategoryList();
        public PoojaCategory GetPoojaCategoryById(int PoojaCategoryId);
    }
}
