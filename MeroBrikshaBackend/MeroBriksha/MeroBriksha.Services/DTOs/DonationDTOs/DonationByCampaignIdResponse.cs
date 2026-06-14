using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.DonationDTOs
{
    public class DonationByCampaignIdResponse
    {
        public string CampaignId { get; set; }
        public string CampaignName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int DonationCount { get; set; }
    }
}

