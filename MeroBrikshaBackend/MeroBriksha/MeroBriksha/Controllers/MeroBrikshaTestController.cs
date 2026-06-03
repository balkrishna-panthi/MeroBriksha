using MeroBriksha.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeroBrikshaTestController : ControllerBase
    {
        IPlant plant;
        public MeroBrikshaTestController(IPlant plantService)
        {
            plant = plantService;
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

        [HttpGet("PlantNames")]
        public List<string> GetAllPlantNames()
        {
            return plant.GetALlPlantNames();   
        }

        [HttpGet("PlantNameById")]
        public string GetPlantNameById(string plantId)
        {
            return plant.GetPlantNameById(plantId);
        }

    }
}
