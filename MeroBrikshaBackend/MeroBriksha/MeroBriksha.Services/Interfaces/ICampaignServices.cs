using MeroBriksha.Services.DTOs.CampaignDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface ICampaignServices
    {
        Task<List<CampaignResponse>> GetAllCampaignsAsync();
        Task<CampaignResponse> GetCampaignByIdAsync(string id);
        Task<CampaignResponse> CreateCampaignAsync(CreateCampaignRequest request);
    }
}
