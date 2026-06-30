using MeroBriksha.Services.DTOs.CampaignDTOs;
using MeroBriksha.Services.DTOs.PlantDtos;

namespace MeroBriksha.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<PlantResponse>> GetAllPlantsAsync();
        Task<PlantResponse> GetPlantByIdAsync(string id);
        Task<PlantResponse> CreatePlantAsync(CreatePlantResponse response);
        Task<PlantResponse> UpdatePlantAsync(UpdatePlantResponse response);
        Task<bool> DeletePlantAsync(string id);
    }
}