using MeroBriksha.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Core.Entities
{
    public class TreeAssignment
    {
        public string ID { get; set; }

        public string DONATIONID { get; set; }
        public Donation Donation { get; set; }

        public TreeAssignmentStatus STATUS { get; set; }

        public string? REMARKS { get; set; }

        public DateTime CREATEDDATE { get; set; }
    }
}
