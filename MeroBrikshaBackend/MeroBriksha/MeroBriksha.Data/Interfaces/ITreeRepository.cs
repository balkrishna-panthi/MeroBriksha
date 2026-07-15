using MeroBriksha.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface ITreeRepository
    {
        Task<Tree?> CreateAsync(Tree tree);
        Task<Tree?> GetByTreeIdAsync(string id);
        Task<Tree?> GetByTrackingIdAsync(string id);
    }
}
