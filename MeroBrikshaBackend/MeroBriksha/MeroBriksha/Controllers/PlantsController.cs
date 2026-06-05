using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }
        [HttpGet("AllPlants")]
        public async Task<IActionResult> GetPlants()
        {
            var plants = await _plantService.GetAllPlantsAsync();
            return Ok(plants);
        }
    }
}
