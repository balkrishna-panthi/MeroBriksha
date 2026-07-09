using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Core.Entities
{
    public class Location
    {
        public string ID { get; set; }
        public string? ADDRESS { get; set; }
        public string? LOCATIONLINK { get; set; }
        public decimal? LATITUDE { get; set; }
        public decimal? LONGITUDE { get; set; }
        public DateTime CREATEDDATE { get; set; } = DateTime.Now;
    }
}
