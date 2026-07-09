using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantSelectionController : ControllerBase
    {
        private readonly IPlantSelectionService _selectPlantService;

        public PlantSelectionController(IPlantSelectionService selectPlantService)
        {
            _selectPlantService = selectPlantService;
        }

        [HttpPut("AssignPlantsToTreeAssignment")]
        public async Task<IActionResult> AssignPlantsToTreeAssignment([FromQuery] string treeAssignmentId, [FromQuery] string plantId)
        {
            var result = await _selectPlantService.AssignPlantsToTreeAssignmentAsync(treeAssignmentId, plantId);
            if (!result)
                return BadRequest("Failed to assign plant to tree assignment.");

            return Ok();
        }

    }
}
