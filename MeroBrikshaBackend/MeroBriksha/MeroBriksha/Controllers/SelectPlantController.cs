using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SelectPlantController : ControllerBase
    {
        private readonly ISelectPlantService _selectPlantService;

        public SelectPlantController(ISelectPlantService selectPlantService)
        {
            _selectPlantService = selectPlantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _selectPlantService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("plant/{plantId}")]
        public async Task<IActionResult> GetByPlantId(string plantId)
        {
            var result = await _selectPlantService.GetByPlantIdAsync(plantId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("treeassignment/{treeAssignmentId}")]
        public async Task<IActionResult> GetByTreeAssignmentId(string treeAssignmentId)
        {
            var result = await _selectPlantService.GetByTreeAssignmentIdAsync(treeAssignmentId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
