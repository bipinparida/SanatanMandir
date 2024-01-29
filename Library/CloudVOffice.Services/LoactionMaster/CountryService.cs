using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Data.DTO.LocationMaster;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.LoactionMaster
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Country> _countryRepo;
        public CountryService(ApplicationDBContext dbContext, ISqlRepository<Country> countryRepo)
        {
            _dbContext = dbContext;
            _countryRepo = countryRepo;
        }
        public MessageEnum CountryCreate(CountryDTO countryDTO)
        {

            try
            {
                var objcheck = _dbContext.Countries.SingleOrDefault(opt => opt.Deleted == false && opt.CountryName == countryDTO.CountryName);
                if (objcheck == null)
                {
                    Country country = new Country();
                    country.CountryName = countryDTO.CountryName;
                    country.CountryCode = countryDTO.CountryCode;
                    country.CreatedBy = countryDTO.CreatedBy;
                    country.CreatedDate = System.DateTime.Now;
                    var obj = _countryRepo.Insert(country);

                    return MessageEnum.Success;

                }
                else
                {
                    return MessageEnum.Duplicate;
                }
            }
            catch
            {
                throw;
            }
        }

        public MessageEnum CountryUpdate(CountryDTO countryDTO)
        {
            try
            {
                var updateCountry = _dbContext.Countries.Where(x => x.CountryId != countryDTO.CountryId && x.CountryName == countryDTO.CountryName && x.CountryCode == countryDTO.CountryCode && x.Deleted == false).FirstOrDefault();
                if (updateCountry == null)
                {
                    var a = _dbContext.Countries.Where(x => x.CountryId == countryDTO.CountryId).FirstOrDefault();
                    if (a != null)
                    {
                        a.CountryName = countryDTO.CountryName;
                        a.CountryCode = countryDTO.CountryCode;
                        a.UpdatedBy = countryDTO.CreatedBy;
                        a.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }

            }
            catch
            {
                throw;
            }
        }

        public MessageEnum DeleteCountry(int CountryId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Countries.Where(x => x.CountryId == CountryId).FirstOrDefault();
                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }

        public Country GetCountryById(int CountryId)
        {
            return _dbContext.Countries.Where(x => x.CountryId == CountryId && x.Deleted == false).SingleOrDefault();
        }

        public List<Country> GetCountryList()
        {
            try
            {
                return _dbContext.Countries.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
