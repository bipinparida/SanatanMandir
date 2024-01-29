using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Data.DTO.LocationMaster;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.LoactionMaster
{
    public class CityService: ICityService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<City> _cityRepo;
        public CityService(ApplicationDBContext dbContext, ISqlRepository<City> cityRepo)
        {
            _dbContext = dbContext;
            _cityRepo = cityRepo;
        }
        public MessageEnum CityCreate(CityDTO cityDTO)
        {
            try
            {
                var objcheck = _dbContext.Cities.SingleOrDefault(opt => opt.Deleted == false && opt.CityName == cityDTO.CityName);

                if (objcheck == null)
                {
                    City city = new City();
                    city.CityName = cityDTO.CityName;
                    city.StateId = cityDTO.StateId;
                    city.CountryId = cityDTO.CountryId;
                    city.CreatedBy = cityDTO.CreatedBy;
                    city.CreatedDate = System.DateTime.Now;
                    var obj = _cityRepo.Insert(city);

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
        public List<City> GetCityList()
        {
            return _dbContext.Cities.Include(s => s.Country).Include(s => s.State).Where(x => x.Deleted == false).ToList();
        }

        public MessageEnum CityUpdate(CityDTO cityDTO)
        {
            try
            {
                var updateCity = _dbContext.Cities.Where(x => x.CityId != cityDTO.CityId && x.CityName == cityDTO.CityName && x.CountryId == cityDTO.CountryId && x.StateId == cityDTO.StateId && x.Deleted == false).FirstOrDefault();

                if (updateCity == null)
                {
                    var a = _dbContext.Cities.Where(x => x.CityId == cityDTO.CityId).FirstOrDefault();
                    if (a != null)
                    {
                        a.CityName = cityDTO.CityName;
                        a.CountryId = cityDTO.CountryId;
                        a.StateId = cityDTO.StateId;
                        a.UpdatedBy = cityDTO.CreatedBy;
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

        public City GetCityByCityId(int CityId)
        {
            return _dbContext.Cities.Where(x => x.CityId == CityId && x.Deleted == false).SingleOrDefault();
        }

        public MessageEnum CityDelete(int CityId, long DeletedBy)
        {
            try
            {
                var a = _dbContext.Cities.Where(x => x.CityId == CityId).FirstOrDefault();
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

        public List<City> GetCityByStateId(int StateId)
        {
            return _dbContext.Cities.Where(x => x.StateId == StateId && x.Deleted == false).ToList();
        }
    }
}
