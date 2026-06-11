using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.TreeAssignmentDTOS
{
    public class TreeAssignmentResponse
    {
        public string Id { get; set; }

        public string DonationId { get; set; }

        public string? DonorId { get; set; }
        public string? DonorName { get; set; }

        public string? CampaignId { get; set; }
        public string? CampaignName { get; set; }

        public decimal DonationAmount { get; set; }

        public string Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
