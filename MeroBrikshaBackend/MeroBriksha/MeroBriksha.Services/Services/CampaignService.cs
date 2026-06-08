using MeroBriksha.Core.Entities;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.CampaignDTOs;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class CampaignService : ICampaignServices
    {
        ICampaignRepository _campaignRepository;    
        public CampaignService(ICampaignRepository campaignRepository) 
        { 
            _campaignRepository = campaignRepository;
        }
        public async Task<List<CampaignResponse>> GetAllCampaignsAsync()
        {
            var campaigns = await _campaignRepository.GetAllCampaignsAsync();
            return campaigns.Select(x => new CampaignResponse()
            {
                Id = x.ID,
                Name = x.NAME,
                Description = x.DESCRIPTION,
                OrganizerName = x.ORGANIZERNAME,
                StartDateUtc = x.STARTDATEUTC
            }).ToList();
        }
        public async Task<CampaignResponse> CreateCampaignAsync(CreateCampaignRequest request)
        {
            Campaign campaign = new Campaign
            {
                ID = Guid.NewGuid().ToString(),
                NAME = request.Name,
                DESCRIPTION = request.Description,
                STARTDATEUTC = request.StartDateUtc,
                ENDDATEUTC = request.EndDateUtc
            };

            var createdCampaign = await _campaignRepository.CreateCampaignAsync(campaign);

            return new CampaignResponse
            {
                Id = createdCampaign.ID,
                Name = createdCampaign.NAME,
                Description = createdCampaign.DESCRIPTION,
                OrganizerName = createdCampaign.ORGANIZERNAME,
                StartDateUtc = createdCampaign.STARTDATEUTC,
                EndDateUtc = createdCampaign.ENDDATEUTC
            };
            throw new NotImplementedException();
        }
    }
}
