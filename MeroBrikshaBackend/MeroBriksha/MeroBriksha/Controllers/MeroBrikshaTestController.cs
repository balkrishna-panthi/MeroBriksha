using MeroBriksha.Data.DBContext;
using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeroBrikshaTestController : ControllerBase
    {
        private readonly IPlantService _plantService;
        private readonly IMeroBrikshaTestService _meroBrikshaTestService;

        public MeroBrikshaTestController(IPlantService plantService, IMeroBrikshaTestService meroBrikshaTestService)
        {
            _plantService = plantService;
            _meroBrikshaTestService = meroBrikshaTestService;
        }
        [HttpGet("ProjectName")]
        public string GetProjectName()
        {
            return "Mero Briksha";
        }
        [HttpGet("ProjectDescription")]
        public string GetProjectDescription()
        {
            return "Mero Briksha is a project focused on tree planting and environmental conservation.";
        }
        [HttpGet("TestDBConnection")]
        public async Task<IActionResult> TestDBConnection()
        {
            return false;
        }

    }
}
