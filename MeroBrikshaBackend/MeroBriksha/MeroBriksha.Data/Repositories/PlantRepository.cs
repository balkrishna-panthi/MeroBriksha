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
            return await _context.Plants.ToListAsync();
        }
    }
}