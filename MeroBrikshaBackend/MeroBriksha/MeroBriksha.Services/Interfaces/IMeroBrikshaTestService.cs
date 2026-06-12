using MeroBriksha.Services.DTOs.PlantDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface IMeroBrikshaTestService
    {
        Task<bool> TestDBConnectionAsync();
    }
}
