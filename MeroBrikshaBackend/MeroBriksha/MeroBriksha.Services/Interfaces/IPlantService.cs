using MeroBriksha.Services.DTOs.CampaignDTOs;
using MeroBriksha.Services.DTOs.PlantDtos;

namespace MeroBriksha.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<PlantResponse>> GetAllPlantsAsync();
        Task<PlantResponse> GetPlantByIdAsync(string id);
        Task<PlantResponse> CreatePlantAsync(CreatePlantRequest request);
        Task<PlantResponse> UpdatePlantAsync(UpdatePlantRequest request);
        Task<bool> DeletePlantAsync(string id);
    }
}