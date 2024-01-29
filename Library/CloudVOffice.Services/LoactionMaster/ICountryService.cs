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
    public interface ICountryService
    {
        public MessageEnum CountryCreate(CountryDTO countryDTO);
        public MessageEnum CountryUpdate(CountryDTO countryDTO);
        public MessageEnum DeleteCountry(int CountryId, Int64 DeletedBy);
        public List<Country> GetCountryList();
        public Country GetCountryById(int CountryId);
    }
}
