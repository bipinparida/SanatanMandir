using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.SanatanMandir.PoojaCategories
{
    public class PoojaCategoryDTO
    {
        public Int64? PoojaCategoryId { get; set; }
        public string PoojaCategoryName { get; set; }

        public Int64 CreatedBy { get; set; }
    }
}
