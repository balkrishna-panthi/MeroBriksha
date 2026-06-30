using MeroBriksha.Core.Entities;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.PlantDtos;
using MeroBriksha.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                Species = x.SPECIES,
                ScientificName= x.SCIENTIFICNAME,
                Description = x.DESCRIPTION
            }).ToList();
        }

        public async Task<PlantResponse?> GetPlantByIdAsync(string id)
        {
            var plant = await _plantRepository.GetPlantByIdAsync(id);

            if (plant == null)
                return null;

            return new PlantResponse
            {
                Id = plant.ID,
                Name = plant.NAME,
                Species = plant.SPECIES,
                ScientificName = plant.SCIENTIFICNAME,
                Description = plant.DESCRIPTION
            };
        }

        public async Task<PlantResponse> CreatePlantAsync(CreatePlantResponse response)
        {
            var plant = new Plant
            {
                NAME = response.Name,
                SPECIES = response.Species,
                SCIENTIFICNAME = response.ScientificName,
                DESCRIPTION = response.Description
            };

            var createdPlant = await _plantRepository.CreatePlantAsync(plant);

            return new PlantResponse
            {
                Id = createdPlant.ID,
                Name = createdPlant.NAME,
                Species = createdPlant.SPECIES,
                ScientificName = createdPlant.SCIENTIFICNAME,
                Description = createdPlant.DESCRIPTION
            };
        }

        public async Task<PlantResponse?> UpdatePlantAsync(UpdatePlantResponse request)
        {
            var plant = new Plant
            {
                ID = request.Id,
                NAME = request.Name,
                SPECIES = request.Species,
                SCIENTIFICNAME = request.ScientificName,
                DESCRIPTION = request.Description
            };

            var updatedPlant = await _plantRepository.UpdatePlantAsync(plant);

            if (updatedPlant == null)
                return null;

            return new PlantResponse
            {
                Id = updatedPlant.ID,
                Name = updatedPlant.NAME,
                Species = updatedPlant.SPECIES,
                ScientificName = updatedPlant.SCIENTIFICNAME,
                Description = updatedPlant.DESCRIPTION
            };
        }

        public async Task<bool> DeletePlantAsync(string id)
        {
            return await _plantRepository.DeletePlantAsync(id);
        }
    }
}

