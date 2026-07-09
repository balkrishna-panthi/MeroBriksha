using MeroBriksha.Services.DTOs.LocationSelectionDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Interfaces
{
    public interface ILocationService
    {
        Task<string> AssignLocationAsync(string treeAssignmentId, AssignLocationRequest location);
    }
}
