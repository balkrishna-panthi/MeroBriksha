using MeroBriksha.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant?> GetPlantByIdAsync(string id);
        Task<Plant> CreatePlantAsync(Plant plant);
        Task<Plant> UpdatePlantAsync(Plant plant);
        Task<bool> DeletePlantAsync(string id);
    }
}
