using MeroBriksha.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface ILocationRepository
    {
        Task<string> AssignLocationAsync(string treeAssignmentId, Location location);
    }
}
