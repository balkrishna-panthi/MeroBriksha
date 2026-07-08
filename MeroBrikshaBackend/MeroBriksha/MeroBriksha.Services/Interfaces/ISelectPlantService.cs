using MeroBriksha.Services.DTOs.SelectPlantDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface ISelectPlantService
    {
        Task<List<SelectPlantResponse>> GetAllAsync();

        Task<SelectPlantResponse?> GetByPlantIdAsync(string plantID);

        Task<SelectPlantResponse?> GetByTreeAssignmentIdAsync(string treeAssignmentID);
    }
}

