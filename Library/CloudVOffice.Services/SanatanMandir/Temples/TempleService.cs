using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanMandir.Temples;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanMandir.Temples;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.SanatanMandir.Temples
{
    public class TempleService: ITempleService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Temple> _templeRepo;
        public TempleService(ApplicationDBContext dbContext, ISqlRepository<Temple> templeRepo)
        {
            _dbContext = dbContext;
            _templeRepo = templeRepo;
        }
        public MessageEnum TempleCreate(TempleDTO templeDTO)
        {

            try
            {
                var objcheck = _dbContext.Temples.SingleOrDefault(opt => opt.Deleted == false && opt.TempleName == templeDTO.TempleName);
                if (objcheck == null)
                {
                    Temple temple = new Temple();
                    temple.TempleName = templeDTO.TempleName;
                    temple.GodName=templeDTO.GodName;
                    temple.CountryId= templeDTO.CountryId;
                    temple.StateId=templeDTO.StateId;
                    temple.CityId = templeDTO.CityId;
                    temple.PoojaCategoryId = templeDTO.PoojaCategoryId;
                    temple.CreatedBy = templeDTO.CreatedBy;
                    temple.CreatedDate = System.DateTime.Now;
                    var obj = _templeRepo.Insert(temple);

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

        public MessageEnum TempleUpdate(TempleDTO templeDTO)
        {
            try
            {
                var updateTemple = _dbContext.Temples.Where(x => x.TempleId != templeDTO.TempleId && x.TempleName == templeDTO.TempleName && x.Deleted == false).FirstOrDefault();
                if (updateTemple == null)
                {
                    var a = _dbContext.Temples.Where(x => x.TempleId == templeDTO.TempleId).FirstOrDefault();
                    if (a != null)
                    {
                        a.TempleName = templeDTO.TempleName;
                        a.GodName = templeDTO.GodName;
                        a.CountryId = templeDTO.CountryId;
                        a.StateId = templeDTO.StateId;
                        a.CityId=templeDTO.CityId;
                        a.PoojaCategoryId=templeDTO.PoojaCategoryId;
                        a.UpdatedBy = templeDTO.CreatedBy;
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

        public MessageEnum DeleteTemple(int TempleId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Temples.Where(x => x.TempleId == TempleId).FirstOrDefault();
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

        public Temple GetTempleById(int TempleId)
        {
            return _dbContext.Temples.Where(x => x.TempleId == TempleId && x.Deleted == false).SingleOrDefault();
        }

        public List<Temple> GetTempleList()
        {
            try
            {
                return _dbContext.Temples.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
        
    }
}
