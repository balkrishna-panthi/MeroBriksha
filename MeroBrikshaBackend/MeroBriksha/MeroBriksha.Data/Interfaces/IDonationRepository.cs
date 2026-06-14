using MeroBriksha.Core.Entities;
using MeroBriksha.Core.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface IDonationRepository
    {
        Task<Donation?> GetByIdAsync(string id);
        Task<CampaignDonationTotalReadModel> TotalDonationByCampaignIdAsync(string id);
        Task<List<Donation>> GetAllAsync();
        Task AddAsync(Donation donation);
        void Update(Donation donation);
        Task SaveChangesAsync();
    }
}
