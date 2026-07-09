
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface IPlantSelectionService
    {
        Task<bool> AssignPlantsToTreeAssignmentAsync(string treeAssignmentId, string plantId);
    }
}

