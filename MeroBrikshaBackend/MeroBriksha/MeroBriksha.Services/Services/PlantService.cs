using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs;
using MeroBriksha.Services.Interfaces;

namespace MeroBriksha.Services.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<List<PlantResponse>> GetAllPlantsAsync()
        {
            var plants = await _plantRepository.GetAllPlantsAsync();

            return plants.Select(x => new PlantResponse
            {
                Id = x.ID,
                Name = x.NAME,
                ScientificName= x.SCIENTIFICNAME,
                Description = x.DESCRIPTION
            }).ToList();
        }
    }
}