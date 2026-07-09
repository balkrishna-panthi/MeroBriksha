using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;

namespace MeroBriksha.Data.Repositories
{
    public class PlantSelectionRepository : IPlantSelectionRepository
    {
        private readonly AppDbContext _context;

        public PlantSelectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignPlantsToTreeAssignmentAsync(string treeAssignmentId, string plantId)
        {
            // Create a stub entity with only the key and the PLANTID to update
            var treeAssignment = new TreeAssignment { ID = treeAssignmentId, PLANTID = plantId };

            // Attach the stub so EF tracks it but doesn't mark all properties as modified
            _context.TreeAssignments.Attach(treeAssignment);

            // Mark only the PLANTID property as modified so only that column is updated
            _context.Entry(treeAssignment).Property(t => t.PLANTID).IsModified = true;


            await _context.SaveChangesAsync();
            return true;

        }
    }
}
