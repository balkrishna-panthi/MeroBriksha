using MeroBriksha.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Core.Entities
{
    public class Donation
    {
        public string ID { get; set; }

        public string DONORID { get; set; }
        public Donor Donor { get; set; }

        public string CAMPAIGNID { get; set; }
        public Campaign Campaign { get; set; }

        public decimal AMOUNT { get; set; }

        public DonationStatus STATUS { get; set; }

        public string? PAYMENTREFERENCE { get; set; }
        public string? REMARKS { get; set; }

        public DateTime CREATEDDATE { get; set; }
        public DateTime? VERIFIEDDATE { get; set; }
    }
}
