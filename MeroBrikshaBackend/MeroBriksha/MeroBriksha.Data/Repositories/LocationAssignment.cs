using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Repositories
{
    public class LocationAssignment : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationAssignment(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AssignLocationAsync(string treeAssignmentId, Location location)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Locations.AddAsync(location);

                // Create a stub entity with only the key and the LOCATIONID to update
                var treeAssignment = new TreeAssignment { ID = treeAssignmentId, LOCATIONID = location.ID};

                // Attach the stub so EF tracks it but doesn't mark all properties as modified
                _context.TreeAssignments.Attach(treeAssignment);

                // Mark only the LOCATIONID property as modified so only that column is updated
                _context.Entry(treeAssignment).Property(t => t.LOCATIONID).IsModified = true;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return location.ID;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}
