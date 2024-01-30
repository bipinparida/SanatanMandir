using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Data.DTO.LocationMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.LoactionMaster
{
    public interface ICityService
    {
        public MessageEnum CityCreate(CityDTO cityDTO);
        public MessageEnum CityUpdate(CityDTO cityDTO);
        public MessageEnum CityDelete(int CityId, Int64 DeletedBy);
        public City GetCityByCityId(int CityId);
        public List<City> GetCityList();
        public List<City> GetCityByStateId(int StateId);
       
    }
}
