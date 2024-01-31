using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Data.DTO.Pandit;
using CloudVOffice.Data.DTO.SanatanUsers;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Pandit
{
    public class PanditRegistrationService : IPanditRegistrationService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<PanditRegistration> _panditRegistrationRepo;
        public PanditRegistrationService(ApplicationDBContext dbContext, ISqlRepository<PanditRegistration> panditRegistrationRepo)
        {
            _dbContext = dbContext;
            _panditRegistrationRepo = panditRegistrationRepo;
        }
        public MessageEnum PanditRegistrationCreate(PanditRegistrationDTO panditRegistrationDTO)
        {

            try
            {
                var objcheck = _dbContext.PanditRegistrations.SingleOrDefault(opt => opt.Deleted == false && opt.PanditName == panditRegistrationDTO.PanditName);
                if (objcheck == null)
                {
                    PanditRegistration panditRegistration = new PanditRegistration();
                    panditRegistration.PanditName = panditRegistrationDTO.PanditName;
                    panditRegistration.TempleId = panditRegistrationDTO.TempleId;
                    panditRegistration.Address = panditRegistrationDTO.Address;
                    panditRegistration.PrimaryPhone = panditRegistrationDTO.PrimaryPhone;
                    panditRegistration.AlternatePhone = panditRegistrationDTO.AlternatePhone;
                    panditRegistration.MailId = panditRegistrationDTO.MailId;
                    panditRegistration.DateOfBirth = panditRegistrationDTO.DateOfBirth;
                    panditRegistration.Password = panditRegistrationDTO.Password;
                    panditRegistration.Image = panditRegistrationDTO.Image;
                    panditRegistration.IsApprove = panditRegistrationDTO.IsApprove;
                    panditRegistration.CreatedBy = panditRegistrationDTO.CreatedBy;
                    panditRegistration.CreatedDate = System.DateTime.Now;
                    var obj = _panditRegistrationRepo.Insert(panditRegistration);

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

        public MessageEnum PanditRegistrationUpdate(PanditRegistrationDTO panditRegistrationDTO)
        {
            try
            {
                var updatePanditRegistration = _dbContext.PanditRegistrations.Where(x => x.PanditRegistrationId != panditRegistrationDTO.PanditRegistrationId && x.PanditName == panditRegistrationDTO.PanditName && x.Deleted == false).FirstOrDefault();
                if (updatePanditRegistration == null)
                {
                    var a = _dbContext.PanditRegistrations.Where(x => x.PanditRegistrationId == panditRegistrationDTO.PanditRegistrationId).FirstOrDefault();
                    if (a != null)
                    {
                        a.PanditName = panditRegistrationDTO.PanditName;
                        a.TempleId = panditRegistrationDTO.TempleId;
                        a.Address = panditRegistrationDTO.Address;
                        a.PrimaryPhone = panditRegistrationDTO.PrimaryPhone;
                        a.AlternatePhone = panditRegistrationDTO.AlternatePhone;
                        a.MailId = panditRegistrationDTO.MailId;
                        a.DateOfBirth = panditRegistrationDTO.DateOfBirth;
                        a.Password = panditRegistrationDTO.Password;
                        a.Image = panditRegistrationDTO.Image;
                        a.IsApprove = panditRegistrationDTO.IsApprove;
                        a.UpdatedBy = panditRegistrationDTO.CreatedBy;
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

        public MessageEnum DeletePanditRegistration(int PanditRegistrationId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.PanditRegistrations.Where(x => x.PanditRegistrationId == PanditRegistrationId).FirstOrDefault();
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

        public PanditRegistration GetPanditRegistrationById(int PanditRegistrationId)
        {
            return _dbContext.PanditRegistrations.Where(x => x.PanditRegistrationId == PanditRegistrationId && x.Deleted == false).SingleOrDefault();
        }

        public List<PanditRegistration> GetPanditRegistrationList()
        {
            try
            {
                return _dbContext.PanditRegistrations.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
