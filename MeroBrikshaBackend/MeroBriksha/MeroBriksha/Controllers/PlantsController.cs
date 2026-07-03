using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.CampaignDTOs;
using MeroBriksha.Services.DTOs.PlantDtos;
using MeroBriksha.Services.Interfaces;
using MeroBriksha.Services.Services;
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

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePlant(CreatePlantRequest plantResponse)
        {
            var plant = await _plantService.CreatePlantAsync(plantResponse);
            return Ok(plant);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdatePlant(UpdatePlantRequest plantResponse)
        {
            var plant = await _plantService.UpdatePlantAsync(plantResponse);
            return Ok(plant);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _plantService.DeletePlantAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
