using MeroBriksha.Services.DTOs;

namespace MeroBriksha.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<PlantResponse>> GetAllPlantsAsync();
    }
}