using MeroBriksha.Services.DTOs.PlantDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    internal interface IMeroBrikshaTestService
    {
        Task<List<PlantResponse>> GetAllPlantsAsync();
    }
}
