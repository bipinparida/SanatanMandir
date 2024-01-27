namespace CloudVOffice.Core.Domain.LocationMaster
{
    public class Country : IAuditEntity, ISoftDeletedEntity
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string? CountryCode { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
