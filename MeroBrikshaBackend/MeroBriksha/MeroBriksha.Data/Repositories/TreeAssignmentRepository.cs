using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Repositories
{
    public class TreeAssignmentRepository : ITreeAssignmentRepository
    {
        private readonly AppDbContext _context;

        public TreeAssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TreeAssignment?> GetByIdAsync(string id)
        {
            return await _context.TreeAssignments
                .Include(x => x.Donation)
                    .ThenInclude(x => x.Donor)
                .Include(x => x.Donation)
                    .ThenInclude(x => x.Campaign)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<TreeAssignment>> GetAllAsync()
        {
            return await _context.TreeAssignments
                .Include(x => x.Donation)
                    .ThenInclude(x => x.Donor)
                .Include(x => x.Donation)
                    .ThenInclude(x => x.Campaign)
                .OrderByDescending(x => x.CREATEDDATE)
                .ToListAsync();
        }

        public async Task<List<TreeAssignment>> GetByDonationIdAsync(string donationId)
        {
            //Load TreeAssignment
            //Then load related Donation
            //Then load Donation's related Donor
            return await _context.TreeAssignments
                .Include(x => x.Donation)
                    .ThenInclude(x => x.Donor)
                .Include(x => x.Donation)
                    .ThenInclude(x => x.Campaign)
                .Where(x => x.DONATIONID == donationId)
                .OrderByDescending(x => x.CREATEDDATE)
                .ToListAsync();
        }

        public async Task AddAsync(TreeAssignment treeAssignment)
        {
            await _context.TreeAssignments.AddAsync(treeAssignment);
        }

        public void Update(TreeAssignment treeAssignment)
        {
            _context.TreeAssignments.Update(treeAssignment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
