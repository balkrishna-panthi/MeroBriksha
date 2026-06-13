using MeroBriksha.Services.DTOs.DonationDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface IDonationService
    {
        Task<DonationResponse> CreateAsync(CreateDonationRequest request);
        Task<List<DonationResponse>> GetAllAsync();
        Task<DonationResponse?> GroupByCampaignIDAsync(string CampaignID);
        Task<DonationResponse?> GetByIdAsync(string id);
        Task<DonationResponse> VerifyAsync(string id);
    }
}
