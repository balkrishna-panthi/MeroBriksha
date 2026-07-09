using MeroBriksha.Core.Enums;
using System;

namespace MeroBriksha.Core.Entities
{
    public class Tree
    {
        public string ID { get; set; }

        // Link to the donation allocation workflow
        public string TREEASSIGNMENTID { get; set; }
        public TreeAssignment TreeAssignment { get; set; }

        // Species information
        public string PLANTID { get; set; }

        // Physical location
        public string? ADDRESS { get; set; }
        public string? LOCATIONLINK { get; set; }
        public decimal? LATITUDE { get; set; }
        public decimal? LONGITUDE { get; set; }

        // Tree lifecycle
        public DateTime PLANTEDDATE { get; set; }

        public TreeStatus STATUS { get; set; }

        // Public identification
        public string TRACKINGCODE { get; set; }

        public DateTime CREATEDDATE { get; set; } = DateTime.UtcNow;
    }
}