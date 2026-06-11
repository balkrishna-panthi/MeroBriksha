using MeroBriksha.Services.DTOs.TreeAssignmentDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface ITreeAssignmentService
    {
        Task<TreeAssignmentResponse> CreateFromDonationAsync(string donationId, CreateTreeAssignmentRequest request);

        Task<List<TreeAssignmentResponse>> GetAllAsync();

        Task<TreeAssignmentResponse?> GetByIdAsync(string id);

        Task<List<TreeAssignmentResponse>> GetByDonationIdAsync(string donationId);
    }
}
