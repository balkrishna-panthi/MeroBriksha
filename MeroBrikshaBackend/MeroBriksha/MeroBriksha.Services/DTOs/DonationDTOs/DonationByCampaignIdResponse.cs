using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.DonationDTOs
{
    public class DonationByCampaignIdResponse
    {
        public string CampaignID { get; set; }
        public decimal TotalAmount { get; set; }
        public int DonationCount { get; set; }
    }
}

