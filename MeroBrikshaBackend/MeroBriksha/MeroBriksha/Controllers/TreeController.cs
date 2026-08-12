using MeroBriksha.Services.DTOs.TreeDTOs;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        ITreeService _treeService { get; set; }
        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTree([FromBody] CreateTreeRequest request)
        {
            var result = await _treeService.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrees()
        {
            var trees = await _treeService.GetAllAsync();
            return Ok(trees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTree([FromRoute] string id)
        {
            var tree = await _treeService.GetByTreeIdAsync(id);
            if (tree == null) return NotFound();
            return Ok(tree);
        }
        
        [HttpGet("tracking/{id}")]
        public async Task<IActionResult> GetTreeByTrackingId([FromRoute] string id)
        {
            var tree = await _treeService.GetByTrackingIdAsync(id);
            if (tree == null) return NotFound();
            return Ok(tree);
        }
    }
}
