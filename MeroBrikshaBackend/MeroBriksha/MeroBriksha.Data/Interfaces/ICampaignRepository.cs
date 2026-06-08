using MeroBriksha.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetAllCampaignsAsync();
        Task<Campaign> CreateCampaignAsync(Campaign campaign);
    }
}
