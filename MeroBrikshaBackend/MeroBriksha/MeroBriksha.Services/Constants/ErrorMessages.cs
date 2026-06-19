using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Constants
{
    public  class ErrorMessages
    {
        public const string DonationNotFound = "Donation not found.";
        public const string CampaignNotFound = "Campaign not found.";
        public static string CampaignNotFoundById(string id) => $"Campaign with ID {id} not found.";

        public const string DonationMustGreaterThanZero = "Donation amount must be greater than zero.";




        public const string DonationAlreadyVerified = "Donation is already verified.";
        public const string DonationRejectedCannotVerify = "Rejected donation cannot be verified.";

    }
}
