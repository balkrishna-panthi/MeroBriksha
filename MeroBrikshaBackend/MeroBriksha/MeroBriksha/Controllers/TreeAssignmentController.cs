using MeroBriksha.Services.DTOs.TreeAssignmentDTOS;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [ApiController]
    [Route("api")]
    public class TreeAssignmentsController : ControllerBase
    {
        private readonly ITreeAssignmentService _treeAssignmentService;

        public TreeAssignmentsController(ITreeAssignmentService treeAssignmentService)
        {
            _treeAssignmentService = treeAssignmentService;
        }

        [HttpPost("donations/{donationId}/tree-assignments")]
        public async Task<IActionResult> CreateFromDonation([FromRoute] string donationId, CreateTreeAssignmentRequest request)
        {
            var result = await _treeAssignmentService.CreateFromDonationAsync(donationId, request);
            return Ok(result);
        }

        [HttpGet("tree-assignments")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _treeAssignmentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("tree-assignments/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _treeAssignmentService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("donations/{donationId}/tree-assignments")]
        public async Task<IActionResult> GetByDonationId([FromRoute] string donationId)
        {
            var result = await _treeAssignmentService.GetByDonationIdAsync(donationId);
            return Ok(result);
        }
    }
}
