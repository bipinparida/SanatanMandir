using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.SanatanMandir.Temples
{
    public class Temple : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 TempleId { get; set; }
        public string TempleName {  get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public Int64 PoojaCategoryId { get; set; }
        public string GodName { get; set; }


        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
