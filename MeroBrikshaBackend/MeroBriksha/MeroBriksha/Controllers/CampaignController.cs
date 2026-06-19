using MeroBriksha.Services.DTOs.CampaignDTOs;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        ICampaignServices _campaignServices;
        public CampaignController(ICampaignServices campaignServices) 
        {
            _campaignServices = campaignServices;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCampaignsAsync()
        {
            return Ok(await _campaignServices.GetAllCampaignsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaignByIdAsync(string id)
        {
            var campaign = await _campaignServices.GetCampaignByIdAsync(id);
            return Ok(campaign);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCampaign(CreateCampaignRequest campaignRequest)
        {
            var campaign = await _campaignServices.CreateCampaignAsync(campaignRequest);
            return Ok(campaign);
        }
    }
}
