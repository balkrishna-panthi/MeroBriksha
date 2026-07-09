using Microsoft.EntityFrameworkCore;
using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;

namespace MeroBriksha.Data.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly AppDbContext _context;

        public PlantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            return await _context.Plants.AsNoTracking().ToListAsync();
        }
        public async Task<Plant?> GetPlantByIdAsync(string id)
        {
            return await _context.Plants.FindAsync(id);
        }
        public async Task<Plant> CreatePlantAsync(Plant plant)
        {
            _context.Add(plant);
            await _context.SaveChangesAsync();
            return plant;
        }
        public async Task<Plant> UpdatePlantAsync(Plant plant)
        {
            var existingPlant = await _context.Plants.FindAsync(plant.ID);

            if (existingPlant == null)
            {
                return null;
            }

            existingPlant.NAME = plant.NAME;
            existingPlant.SPECIES = plant.SPECIES;
            existingPlant.SCIENTIFICNAME = plant.SCIENTIFICNAME;
            existingPlant.DESCRIPTION = plant.DESCRIPTION;
            

            await _context.SaveChangesAsync();

            return existingPlant;
        }

        public async Task<bool> DeletePlantAsync(string id)
        {
            var plant = await _context.Plants.FindAsync(id);

            if (plant == null)
                return false;

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
