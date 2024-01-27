using System.ComponentModel.DataAnnotations.Schema;

namespace CloudVOffice.Core.Domain.LocationMaster
{
    public class City : IAuditEntity, ISoftDeletedEntity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }


        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }
    }
}
