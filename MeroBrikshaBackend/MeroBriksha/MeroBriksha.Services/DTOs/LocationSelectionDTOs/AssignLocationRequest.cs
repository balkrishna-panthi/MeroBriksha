using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.LocationSelectionDTOs
{
    public class AssignLocationRequest
    {
        public string TreeAssignmentId { get; set; }

        public string? Address { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? LocationLink { get; set; }

    }
}
