using MeroBriksha.Services.DTOs.PlantDtos;

namespace MeroBriksha.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<PlantResponse>> GetAllPlantsAsync();
    }
}