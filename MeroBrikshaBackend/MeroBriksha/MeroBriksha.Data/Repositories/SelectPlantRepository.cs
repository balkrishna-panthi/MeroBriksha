using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace MeroBriksha.Data.Repositories
{
    public class SelectPlantRepository : ISelectPlantRepository
    {
        private readonly AppDbContext _context;

        public SelectPlantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SelectPlant>> GetAllAsync()
        {
            return await _context.SelectPlants.ToListAsync();
        }

        public async Task<SelectPlant?> GetByPlantIdAsync(string plantId)
        {
            return await _context.SelectPlants
                .FirstOrDefaultAsync(x => x.PlantID == plantId);
        }

        public async Task<SelectPlant?> GetByTreeAssignmentIdAsync(string treeAssignmentId)
        {
            return await _context.SelectPlants
                .FirstOrDefaultAsync(x => x.TreeAssignmentID == treeAssignmentId);
        }

    }
}
