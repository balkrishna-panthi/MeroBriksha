using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroBriksha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeroBrikshaTestController : ControllerBase
    {
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
