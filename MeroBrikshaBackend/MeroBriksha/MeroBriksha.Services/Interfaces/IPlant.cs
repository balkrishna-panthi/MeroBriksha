using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeroBriksha.Services.Interfaces
{
    public interface IPlant
    {
        List<string> GetALlPlantNames();
        string GetPlantNameById(string plantId);

    }
}
