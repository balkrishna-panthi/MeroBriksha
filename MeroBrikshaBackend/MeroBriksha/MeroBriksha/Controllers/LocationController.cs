using MeroBriksha.Services.DTOs.LocationSelectionDTOs;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost("AssignLocation")]
        public async Task<IActionResult> AssignLocation([FromBody] AssignLocationRequest location)
        {
            return Ok(await _locationService.AssignLocationAsync(location.TreeAssignmentId, location));
        }
    }
}
