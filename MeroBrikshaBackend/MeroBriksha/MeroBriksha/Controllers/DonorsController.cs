using MeroBriksha.Services.DTOs.DonorDtos;
using MeroBriksha.Services.DTOs.Donors;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorsController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet("GetDonors")]
        public async Task<IActionResult> GetDonors()
        {
            var donors = await _donorService.GetAllDonorsAsync();
            return Ok(donors);
        }

        [HttpPost("RegisterDonor")]
        public async Task<IActionResult> CreateDonor(CreateDonorRequest request)
        {
            var donor = await _donorService.CreateDonorAsync(request);
            return Ok(donor);
        }
    }
}