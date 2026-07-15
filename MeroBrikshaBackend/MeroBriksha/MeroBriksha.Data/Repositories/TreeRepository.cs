using MeroBriksha.Core.Entities;
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

        public async Task<Tree?> GetByTrackingIdAsync(string id)
        {
           _context.ChangeTracker.Clear();
            var tree = await _context.Trees.FindAsync(id);
            return tree;
        }
        

        public async Task<Tree?> GetByTreeIdAsync(string id)
        {
            _context.ChangeTracker.Clear();
            var tree = await _context.Trees.FindAsync(id);
            return tree;
        }
    }
}
