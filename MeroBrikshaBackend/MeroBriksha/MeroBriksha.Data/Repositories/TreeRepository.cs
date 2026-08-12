using MeroBriksha.Core.Entities;
using MeroBriksha.Core.ReadModels;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private readonly AppDbContext _context;

        public TreeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tree?> CreateAsync(Tree tree)
        {
            _context.Add(tree);
            await _context.SaveChangesAsync();
            return tree;
        }
        public async Task<List<TreeDetailsReadModel>> GetAllAsync()
        {
            var trees = await _context.Trees.ToListAsync();
            return trees.Select(tree => new TreeDetailsReadModel
            {
                Id = tree?.ID ?? string.Empty,
                TreeAssignmentId = tree?.TREEASSIGNMENTID ?? string.Empty,
                Name = _context.Plants.FindAsync(tree?.PLANTID).Result?.NAME ?? string.Empty,
                Description = _context.Plants.FindAsync(tree?.PLANTID).Result?.DESCRIPTION ?? string.Empty,
                Species = _context.Plants.FindAsync(tree?.PLANTID).Result?.SPECIES ?? string.Empty,
                DonorName = _context.TreeAssignments.FindAsync(tree?.TREEASSIGNMENTID).Result?.ID ?? string.Empty
            }).ToList();
        }

        public async Task<TreeDetailsReadModel?> GetByTrackingIdAsync(string id)
        {
           _context.ChangeTracker.Clear();
            var tree = await _context.Trees.FirstOrDefaultAsync(tree => tree.TRACKINGCODE == id);
            return new TreeDetailsReadModel
            {
                Id = tree?.ID ?? string.Empty,
                TreeAssignmentId = tree?.TREEASSIGNMENTID ?? string.Empty,
                Name = _context.Plants.FindAsync(tree?.PLANTID).Result?.NAME ?? string.Empty,
                Description = _context.Plants.FindAsync(tree?.PLANTID).Result?.DESCRIPTION ?? string.Empty,
                Species = _context.Plants.FindAsync(tree?.PLANTID).Result?.SPECIES ?? string.Empty,
                DonorName = _context.TreeAssignments.FindAsync(tree?.TREEASSIGNMENTID).Result?.ID ?? string.Empty
            };
        }
        
        public async Task<TreeDetailsReadModel?> GetByTreeIdAsync(string id)
        {
            _context.ChangeTracker.Clear();
            var tree = await _context.Trees.FindAsync(id);
            return new TreeDetailsReadModel
            {
                Id = tree?.ID ?? string.Empty,
                TreeAssignmentId = tree?.TREEASSIGNMENTID ?? string.Empty,
                Name = _context.Plants.FindAsync(tree?.PLANTID).Result?.NAME ?? string.Empty,
                Description = _context.Plants.FindAsync(tree?.PLANTID).Result?.DESCRIPTION ?? string.Empty,
                Species = _context.Plants.FindAsync(tree?.PLANTID).Result?.SPECIES ?? string.Empty,
                DonorName = _context.TreeAssignments.FindAsync(tree?.TREEASSIGNMENTID).Result?.ID ?? string.Empty
            };
        }
        
    }
}
