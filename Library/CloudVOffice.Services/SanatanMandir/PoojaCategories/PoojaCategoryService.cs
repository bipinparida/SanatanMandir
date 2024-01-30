using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.LocationMaster;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.SanatanMandir.PoojaCategories
{
    public class PoojaCategoryService: IPoojaCategoryService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<PoojaCategory> _poojaCategoryRepo;
        public PoojaCategoryService(ApplicationDBContext dbContext, ISqlRepository<PoojaCategory> poojaCategoryRepo)
        {
            _dbContext = dbContext;
            _poojaCategoryRepo = poojaCategoryRepo;
        }
        public MessageEnum PoojaCategoryCreate(PoojaCategoryDTO poojaCategoryDTO)
        {

            try
            {
                var objcheck = _dbContext.PoojaCategories.SingleOrDefault(opt => opt.Deleted == false && opt.PoojaCategoryName == poojaCategoryDTO.PoojaCategoryName);
                if (objcheck == null)
                {
                    PoojaCategory poojaCategory = new PoojaCategory();
                    poojaCategory.PoojaCategoryName = poojaCategoryDTO.PoojaCategoryName;
                    poojaCategory.CreatedBy = poojaCategoryDTO.CreatedBy;
                    poojaCategory.CreatedDate = System.DateTime.Now;
                    var obj = _poojaCategoryRepo.Insert(poojaCategory);

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

        public MessageEnum PoojaCategoryUpdate(PoojaCategoryDTO poojaCategoryDTO)
        {
            try
            {
                var updatePoojaCategory = _dbContext.PoojaCategories.Where(x => x.PoojaCategoryId != poojaCategoryDTO.PoojaCategoryId && x.PoojaCategoryName == poojaCategoryDTO.PoojaCategoryName && x.Deleted == false).FirstOrDefault();
                if (updatePoojaCategory == null)
                {
                    var a = _dbContext.PoojaCategories.Where(x => x.PoojaCategoryId == poojaCategoryDTO.PoojaCategoryId).FirstOrDefault();
                    if (a != null)
                    {
                        a.PoojaCategoryName = poojaCategoryDTO.PoojaCategoryName;
                        a.UpdatedBy = poojaCategoryDTO.CreatedBy;
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

        public MessageEnum DeletePoojaCategory(int PoojaCategoryId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.PoojaCategories.Where(x => x.PoojaCategoryId == PoojaCategoryId).FirstOrDefault();
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

        public PoojaCategory GetPoojaCategoryById(int PoojaCategoryId)
        {
            return _dbContext.PoojaCategories.Where(x => x.PoojaCategoryId == PoojaCategoryId && x.Deleted == false).SingleOrDefault();
        }

        public List<PoojaCategory> GetPoojaCategoryList()
        {
            try
            {
                return _dbContext.PoojaCategories.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
