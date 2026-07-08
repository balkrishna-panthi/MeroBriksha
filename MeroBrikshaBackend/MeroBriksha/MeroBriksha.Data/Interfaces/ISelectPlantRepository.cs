using MeroBriksha.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface ISelectPlantRepository
    {
        Task<List<SelectPlant>> GetAllAsync();

        Task<SelectPlant> GetByPlantIdAsync(string plantId);

        Task<SelectPlant> GetByTreeAssignmentIdAsync(string treeAssignmentId);

    }
}
