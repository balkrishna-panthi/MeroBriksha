using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.PlantDtos
{
    public class DeletePlantResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string? ScientificName { get; set; }
        public string? Description { get; set; }
    }
}
