
using MeroBriksha.Services.DTOs.TreeDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface ITreeService
    {
        Task<CreateTreeResponse?> CreateAsync(CreateTreeRequest request);
        Task<List<TreeDetails>> GetAllAsync();
        Task<TreeDetails?> GetByTreeIdAsync(string id);
        Task<TreeDetails?> GetByTrackingIdAsync(string id);
    }
}
