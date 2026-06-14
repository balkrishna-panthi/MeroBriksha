using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Core.ReadModels
{
    public class CampaignDonationTotalReadModel
    {
        public string CampaignId { get; set; } = string.Empty;
        public string CampaignName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        public int DonationCount { get; set; }
    }
}
