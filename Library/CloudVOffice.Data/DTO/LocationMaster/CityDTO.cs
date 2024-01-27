namespace CloudVOffice.Data.DTO.LocationMaster
{
    public class CityDTO
    {
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
