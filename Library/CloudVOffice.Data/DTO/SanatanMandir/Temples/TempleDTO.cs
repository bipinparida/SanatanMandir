﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.SanatanMandir.Temples
{
    public class TempleDTO
    {
        public Int64? TempleId { get; set; }
        public string TempleName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        //public Int64 PoojaCategoryId { get; set; }
        public string GodName { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageUp { get; set; }


        public Int64 CreatedBy { get; set; }
    }
}
