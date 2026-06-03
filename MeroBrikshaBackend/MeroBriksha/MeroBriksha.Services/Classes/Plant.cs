using MeroBriksha.Core;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MeroBriksha.Services.Classes
{
    public class Plant : IPlant
    {
        public List<string> GetALlPlantNames()
        {
            List<string> PlantNames = new List<string>()
            {
                "Oak",
                "Pine",
                "Maple",
                "Birch",
                "Willow",
                "Cedar",
                "Redwood",
                "Spruce",
                "Fir",
                "Cherry Blossom"
            };

            return PlantNames;
        }

        public string GetPlantNameById(string plantId)
        {
            List<MeroBriksha.Core.Plant> Plants = new List<MeroBriksha.Core.Plant>()
            {
                new Core.Plant { ID = "1", NAME = "Oak" },
                new Core.Plant { ID = "2", NAME = "Pine" },
                new Core.Plant { ID = "3", NAME = "Maple" },
                new Core.Plant { ID = "4", NAME = "Birch" },
                new Core.Plant { ID = "5", NAME = "Willow" },
                new Core.Plant { ID = "6", NAME = "Cedar" },
                new Core.Plant { ID = "7", NAME = "Redwood" },
                new Core.Plant { ID = "8", NAME = "Spruce" },
                new Core.Plant { ID = "9", NAME = "Fir" },
                new Core.Plant { ID = "10", NAME = "Cherry Blossom" }
            };

            var plant = Plants.FirstOrDefault(p => p.ID == plantId);
            return plant != null ? plant.NAME : null;
        }
    }
}
