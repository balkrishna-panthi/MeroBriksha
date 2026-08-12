using MeroBriksha.Core.Entities;
using MeroBriksha.Core.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface ITreeRepository
    {
        Task<Tree?> CreateAsync(Tree tree);
        Task<List<TreeDetailsReadModel>> GetAllAsync();
        Task<TreeDetailsReadModel?> GetByTreeIdAsync(string id);
        Task<TreeDetailsReadModel?> GetByTrackingIdAsync(string id);
    }
}
