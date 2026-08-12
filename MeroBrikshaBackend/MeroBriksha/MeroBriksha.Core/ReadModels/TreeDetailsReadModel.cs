using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Core.ReadModels
{
    public class TreeDetailsReadModel
    {
        public string Id { get; set; } = string.Empty;
        public string TreeAssignmentId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public string Species { get; set; } = string.Empty;
        public string DonorName { get; set; } = string.Empty;
    }
}
