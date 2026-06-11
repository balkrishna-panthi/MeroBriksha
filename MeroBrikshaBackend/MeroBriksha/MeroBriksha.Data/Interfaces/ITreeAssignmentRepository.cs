using MeroBriksha.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface ITreeAssignmentRepository
    {
        Task<TreeAssignment?> GetByIdAsync(string id);
        Task<List<TreeAssignment>> GetAllAsync();
        Task<List<TreeAssignment>> GetByDonationIdAsync(string donationId);
        Task AddAsync(TreeAssignment treeAssignment);
        void Update(TreeAssignment treeAssignment);
        Task SaveChangesAsync();
    }
}
