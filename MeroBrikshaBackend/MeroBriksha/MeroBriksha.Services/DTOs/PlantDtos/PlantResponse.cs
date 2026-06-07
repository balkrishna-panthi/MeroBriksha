namespace MeroBriksha.Services.DTOs.PlantDtos
{
    public class PlantResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? ScientificName { get; set; }
        public string? Description { get; set; }
    }
}