using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class PlantSelectionService : IPlantSelectionService
    {
        private readonly IPlantSelectionRepository _repository;

        public PlantSelectionService(IPlantSelectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AssignPlantsToTreeAssignmentAsync(string treeAssignmentId, string plantId)
        {
            return await _repository.AssignPlantsToTreeAssignmentAsync(treeAssignmentId, plantId);
        }
    }
}

