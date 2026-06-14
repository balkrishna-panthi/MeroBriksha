using MeroBriksha.Core.Entities;
using MeroBriksha.Core.Enums;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.DonationDTOs;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly ICampaignRepository _campaignRepository;

        public DonationService(
            IDonationRepository donationRepository,
            IDonorRepository donorRepository,
            ICampaignRepository campaignRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _campaignRepository = campaignRepository;
        }

        public async Task<DonationResponse> CreateAsync(CreateDonationRequest request)
        {
            if (request.Amount <= 0)
                throw new Exception("Donation amount must be greater than zero.");

            var donor = await _donorRepository.GetDonorByIdAsync(request.DonorId);
            if (donor == null)
                throw new Exception("Donor not found.");

            var campaign = await _campaignRepository.GetCampaignByIdAsync(request.CampaignId);
            if (campaign == null)
                throw new Exception("Campaign not found.");

            var donation = new Donation
            {
                ID = Guid.NewGuid().ToString(),
                DONORID = request.DonorId,
                CAMPAIGNID = request.CampaignId,
                AMOUNT = request.Amount,
                PAYMENTREFERENCE = request.PaymentReference,
                REMARKS = request.Remarks,
                STATUS = DonationStatus.Registered
            };

            await _donationRepository.AddAsync(donation);
            await _donationRepository.SaveChangesAsync();

            return new DonationResponse
            {
                Id = donation.ID,
                DonorId = donor.ID,
                DonorName = donor.FULLNAME,
                CampaignId = campaign.ID,
                CampaignName = campaign.NAME,
                Amount = donation.AMOUNT,
                Status = donation.STATUS.ToString(),
                PaymentReference = donation.PAYMENTREFERENCE,
                Remarks = donation.REMARKS,
                CreatedDate = donation.CREATEDDATE,
                VerifiedDate = donation.VERIFIEDDATE
            };
        }

        public async Task<List<DonationResponse>> GetAllAsync()
        {
            var donations = await _donationRepository.GetAllAsync();

            return donations.Select(ToResponse).ToList();
        }

        public async Task<DonationResponse?> GetByIdAsync(string id)
        {
            var donation = await _donationRepository.GetByIdAsync(id);

            if (donation == null)
                return null;

            return ToResponse(donation);
        }

        public async Task<DonationResponse> VerifyAsync(string id)
        {
            var donation = await _donationRepository.GetByIdAsync(id);

            if (donation == null)
                throw new Exception("Donation not found.");

            if (donation.STATUS == DonationStatus.Verified)
                throw new Exception("Donation is already verified.");

            if (donation.STATUS == DonationStatus.Rejected)
                throw new Exception("Rejected donation cannot be verified.");

            donation.STATUS = DonationStatus.Verified;
            donation.VERIFIEDDATE = DateTime.UtcNow;

            _donationRepository.Update(donation);
            await _donationRepository.SaveChangesAsync();

            return ToResponse(donation);
        }

        private static DonationResponse ToResponse(Donation donation)
        {
            return new DonationResponse
            {
                Id = donation.ID,

                DonorId = donation.DONORID,
                DonorName = donation.Donor?.FULLNAME,

                CampaignId = donation.CAMPAIGNID,
                CampaignName = donation.Campaign?.NAME,

                Amount = donation.AMOUNT,
                Status = donation.STATUS.ToString(),

                PaymentReference = donation.PAYMENTREFERENCE,
                Remarks = donation.REMARKS,

                CreatedDate = donation.CREATEDDATE,
                VerifiedDate = donation.VERIFIEDDATE
            };
        }

        public async Task<DonationByCampaignIdResponse> TotalDonationByCampaignIdAsync(string CampaignID)
        {
            var donations = await _donationRepository.TotalDonationByCampaignIdAsync(CampaignID);

            return new DonationByCampaignIdResponse
            {
                CampaignId = donations.CampaignId,
                CampaignName = donations.CampaignName,
                TotalAmount = donations.TotalAmount,
                DonationCount = donations.DonationCount
            };
        }
    }
}
