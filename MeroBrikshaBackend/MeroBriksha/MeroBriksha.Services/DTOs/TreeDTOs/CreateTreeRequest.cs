using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.TreeDTOs
{
    public class CreateTreeRequest
    {
        public string TreeAssignmentId { get; set; } = string.Empty;
        public string PlantId { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? LocationLink { get; set; }
        public decimal? Latitude { get; set; } 
        public decimal? Longitude { get; set; } 
        public DateTime PlantedDate { get; set; } = DateTime.UtcNow;
    }
}
