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

        public MeroBrikshaTestController(IPlantService plantService)
        {
            _plantService = plantService;
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

    }
}
