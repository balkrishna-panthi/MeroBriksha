using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.DonationDTOs
{
    public class DonationResponse
    {
        public string Id { get; set; }

        public string DonorId { get; set; }
        public string? DonorName { get; set; }

        public string CampaignId { get; set; }
        public string? CampaignName { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public string? PaymentReference { get; set; }
        public string? Remarks { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
    }
}
