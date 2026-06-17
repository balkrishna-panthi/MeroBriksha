using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.DonationDTOs
{
    public class DonationPerCampaignResponse
    {
        public List<DonationByCampaignIdResponse> PerCampaignDonations { get; set; }
    }
}
