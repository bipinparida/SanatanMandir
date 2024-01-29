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
    public class StateService: IStateService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<State> _stateRepo;
        public StateService(ApplicationDBContext dbContext, ISqlRepository<State> stateRepo)
        {
            _dbContext = dbContext;
            _stateRepo = stateRepo;
        }

        public MessageEnum StateCreate(StateDTO stateDTO)
        {
            try
            {
                var objcheck = _dbContext.States.SingleOrDefault(opt => opt.Deleted == false && opt.StateName == stateDTO.StateName);
                if (objcheck == null)
                {
                    State state = new State();
                    state.StateName = stateDTO.StateName;
                    state.CountryId = stateDTO.CountryId;
                    state.CreatedBy = stateDTO.CreatedBy;
                    state.CreatedDate = System.DateTime.Now;
                    var obj = _stateRepo.Insert(state);

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
        public List<State> GetStateList()
        {
            try
            {
                return _dbContext.States.Include(s => s.Country).Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
        public MessageEnum StateUpdate(StateDTO stateDTO)
        {
            try
            {
                var updateS = _dbContext.States.Where(x => x.StateId != stateDTO.StateId && x.StateName == stateDTO.StateName && x.CountryId == stateDTO.CountryId && x.Deleted == false).FirstOrDefault();
                if (updateS == null)
                {
                    var a = _dbContext.States.Where(x => x.StateId == stateDTO.StateId).FirstOrDefault();
                    if (a != null)
                    {
                        a.StateName = stateDTO.StateName;
                        a.CountryId = stateDTO.CountryId;
                        a.UpdatedBy = stateDTO.CreatedBy;
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
        public State GetStateByStateId(int StateId)
        {
            return _dbContext.States.Where(x => x.StateId == StateId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum DeleteState(int StateId, long DeletedBy)
        {
            try
            {
                var a = _dbContext.States.Where(x => x.StateId == StateId).FirstOrDefault();
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

        public List<State> GetStateByCountryId(int CountryId)
        {
            return _dbContext.States.Where(x => x.CountryId == CountryId && x.Deleted == false).ToList();
        }
    }
}
