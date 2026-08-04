using MeroBriksha.Core.Entities;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.Constants;
using MeroBriksha.Services.DTOs.CampaignDTOs;
using MeroBriksha.Services.Interfaces;
using MeroBriksha.Services.Services.Exceptions;
using System;
using System.Collections.Generic;
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
                StartDateUtc = x.STARTDATEUTC,
                EndDateUtc = x.ENDDATEUTC
            }).ToList();
        }
        public async Task<CampaignResponse> GetCampaignByIdAsync(string id)
        {
            var campaign = await _campaignRepository.GetCampaignByIdAsync(id);
            if (campaign == null)
            {
                throw new NotFoundException(ErrorMessages.CampaignNotFoundById(id));
            }
            return new CampaignResponse
            {
                Id = campaign.ID,
                Name = campaign.NAME,
                Description = campaign.DESCRIPTION,
                OrganizerName = campaign.ORGANIZERNAME,
                StartDateUtc = campaign.STARTDATEUTC,
                EndDateUtc = campaign.ENDDATEUTC
            };
        }
        public async Task<CampaignResponse> CreateCampaignAsync(CreateCampaignRequest request)
        {
            Campaign campaign = new Campaign
            {
                ID = Guid.NewGuid().ToString(),
                NAME = request.Name,
                ORGANIZERNAME = request.OrganizerName,
                DESCRIPTION = request.Description,
                STARTDATEUTC = request.StartDateUtc,
                ENDDATEUTC = request.EndDateUtc,
                TARGETTREECOUNT = request.TargetTreeCount
            };

            var createdCampaign = await _campaignRepository.CreateCampaignAsync(campaign);

            return new CampaignResponse
            {
                Id = createdCampaign.ID,
                Name = createdCampaign.NAME,
                Description = createdCampaign.DESCRIPTION,
                OrganizerName = createdCampaign.ORGANIZERNAME,
                StartDateUtc = createdCampaign.STARTDATEUTC,
                EndDateUtc = createdCampaign.ENDDATEUTC,
                TargetTreeCount = createdCampaign.TARGETTREECOUNT
            };
            throw new NotImplementedException();
        }
        public async Task<CampaignResponse> UpdateCampaignAsync(UpdateCampaignRequest request)
        {

            var campaign = await _campaignRepository.GetCampaignByIdAsync(request.Id);

            if (campaign == null)
            {
                throw new ValidationException($"Campaign with ID {request.Id} not found.");
            }

            campaign.NAME = request.Name;
            campaign.DESCRIPTION = request.Description;
            campaign.ORGANIZERNAME = request.OrganizerName;

            var updatedCampaign = await _campaignRepository.UpdateCampaignAsync(campaign);

            return new CampaignResponse
            {
                Id = updatedCampaign.ID,
                Name = updatedCampaign.NAME,
                Description = updatedCampaign.DESCRIPTION,
                OrganizerName = updatedCampaign.ORGANIZERNAME
                
            };
        }

        public async Task<bool> DeleteCampaignAsync(string id)
        {
            var campaign = await _campaignRepository.GetCampaignByIdAsync(id);
            if (campaign == null)
            {
                throw new NotFoundException(ErrorMessages.CampaignNotFoundById(id));
            }
            return await _campaignRepository.DeleteCampaignAsync(id);
        }
    }
}
