using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.DonationDTOs
{
    public class CreateDonationRequest
    {
        public string DonorId { get; set; }
        public string CampaignId { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentReference { get; set; }
        public string? Remarks { get; set; }
    }
}
