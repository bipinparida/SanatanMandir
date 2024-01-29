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
    public interface IStateService
    {
        public MessageEnum StateCreate(StateDTO stateDTO);
        public MessageEnum StateUpdate(StateDTO stateDTO);
        public MessageEnum DeleteState(int StateId, Int64 DeletedBy);
        public State GetStateByStateId(int StateId);
        public List<State> GetStateList();
        public List<State> GetStateByCountryId(int CountryId);
    }
}
