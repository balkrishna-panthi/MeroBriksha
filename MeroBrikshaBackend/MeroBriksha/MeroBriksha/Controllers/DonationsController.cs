using MeroBriksha.Services.DTOs.DonationDTOs;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonationsController : ControllerBase
{
    private readonly IDonationService _donationService;

    public DonationsController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateDonationRequest request)
    {
        var result = await _donationService.CreateAsync(request);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _donationService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _donationService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("Verify/{id}")]
    public async Task<IActionResult> Verify(string id)
    {
        var result = await _donationService.VerifyAsync(id);
        return Ok(result);
    }

    [HttpGet("GroupByCampaignID/{id}")]
    public async Task<IActionResult> GroupByCampaignID(string CampaignID)
    {
        var result = await _donationService.GroupByCampaignIDAsync(CampaignID);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

}