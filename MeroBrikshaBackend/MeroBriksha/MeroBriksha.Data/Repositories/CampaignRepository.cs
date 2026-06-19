using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly AppDbContext _context;

        public CampaignRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Campaign>> GetAllCampaignsAsync()
        {
            return await _context.Campaigns.ToListAsync();
        }
        public async Task<Campaign> GetCampaignByIdAsync(string id)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.ID == id);
            return campaign;
        }
        public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
        {
            _context.Add(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }
        public async Task<Campaign> UpdateCampaignAsync(Campaign campaign)
        {
            var existingCampaign = await _context.Campaigns
       .FirstOrDefaultAsync(x => x.ID == campaign.ID);

            if (existingCampaign == null)
            {
                return null;
            }

            existingCampaign.NAME = campaign.NAME;
            existingCampaign.DESCRIPTION = campaign.DESCRIPTION;
            existingCampaign.ORGANIZERNAME = campaign.ORGANIZERNAME;

            await _context.SaveChangesAsync();

            return existingCampaign;
        }
    }
}
