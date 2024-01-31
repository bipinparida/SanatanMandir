using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanUsers;
using CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories;
using CloudVOffice.Data.DTO.SanatanUsers;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.SanatanUsers
{
    public class SanatanUserService: ISanatanUserService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SanatanUser> _sanatanUserRepo;
        public SanatanUserService(ApplicationDBContext dbContext, ISqlRepository<SanatanUser> sanatanUserRepo)
        {
            _dbContext = dbContext;
            _sanatanUserRepo = sanatanUserRepo;
        }
        public MessageEnum SanatanUserCreate(SanatanUserDTO sanatanUserDTO)
        {

            try
            {
                var objcheck = _dbContext.SanatanUsers.SingleOrDefault(opt => opt.Deleted == false && opt.SanatanUserName == sanatanUserDTO.SanatanUserName);
                if (objcheck == null)
                {
                    SanatanUser sanatanUser = new SanatanUser();
                    sanatanUser.SanatanUserName = sanatanUserDTO.SanatanUserName;
                    sanatanUser.CreatedBy = sanatanUserDTO.CreatedBy;
                    sanatanUser.CreatedDate = System.DateTime.Now;
                    var obj = _sanatanUserRepo.Insert(sanatanUser);

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

        public MessageEnum SanatanUserUpdate(SanatanUserDTO sanatanUserDTO)
        {
            try
            {
                var updateSanatanUser = _dbContext.SanatanUsers.Where(x => x.SanatanUserId != sanatanUserDTO.SanatanUserId && x.SanatanUserName == sanatanUserDTO.SanatanUserName && x.Deleted == false).FirstOrDefault();
                if (updateSanatanUser == null)
                {
                    var a = _dbContext.SanatanUsers.Where(x => x.SanatanUserId == sanatanUserDTO.SanatanUserId).FirstOrDefault();
                    if (a != null)
                    {
                        a.SanatanUserName = sanatanUserDTO.SanatanUserName;
                        a.UpdatedBy = sanatanUserDTO.CreatedBy;
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

        public MessageEnum DeleteSanatanUser(int SanatanUserId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.SanatanUsers.Where(x => x.SanatanUserId == SanatanUserId).FirstOrDefault();
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

        public SanatanUser GetSanatanUserById(int SanatanUserId)
        {
            return _dbContext.SanatanUsers.Where(x => x.SanatanUserId == SanatanUserId && x.Deleted == false).SingleOrDefault();
        }

        public List<SanatanUser> GetSanatanUserList()
        {
            try
            {
                return _dbContext.SanatanUsers.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
