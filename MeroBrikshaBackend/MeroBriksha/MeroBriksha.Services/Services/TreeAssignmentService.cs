using MeroBriksha.Core.Entities;
using MeroBriksha.Core.Enums;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.TreeAssignmentDTOS;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class TreeAssignmentService : ITreeAssignmentService
    {
        private readonly ITreeAssignmentRepository _treeAssignmentRepository;
        private readonly IDonationRepository _donationRepository;

        public TreeAssignmentService(
            ITreeAssignmentRepository treeAssignmentRepository,
            IDonationRepository donationRepository)
        {
            _treeAssignmentRepository = treeAssignmentRepository;
            _donationRepository = donationRepository;
        }

        public async Task<TreeAssignmentResponse> CreateFromDonationAsync(string donationId, CreateTreeAssignmentRequest request)
        {
            var donation = await _donationRepository.GetByIdAsync(donationId);

            if (donation == null)
                throw new Exception("Donation not found.");

            if (donation.STATUS != DonationStatus.Verified)
                throw new Exception("Only verified donations can be assigned to trees.");

            var treeAssignment = new TreeAssignment
            {
                ID = Guid.NewGuid().ToString(),
                DONATIONID = donationId,
                STATUS = TreeAssignmentStatus.Pending,
                REMARKS = request.Remarks
            };

            await _treeAssignmentRepository.AddAsync(treeAssignment);
            await _treeAssignmentRepository.SaveChangesAsync();

            var savedAssignment = await _treeAssignmentRepository.GetByIdAsync(treeAssignment.ID);

            return ToResponse(savedAssignment!);
        }

        public async Task<List<TreeAssignmentResponse>> GetAllAsync()
        {
            var assignments = await _treeAssignmentRepository.GetAllAsync();

            return assignments.Select(ToResponse).ToList();
        }

        public async Task<TreeAssignmentResponse?> GetByIdAsync(string id)
        {
            var assignment = await _treeAssignmentRepository.GetByIdAsync(id);

            if (assignment == null)
                return null;

            return ToResponse(assignment);
        }

        public async Task<List<TreeAssignmentResponse>> GetByDonationIdAsync(string donationId)
        {
            var assignments = await _treeAssignmentRepository.GetByDonationIdAsync(donationId);

            return assignments.Select(ToResponse).ToList();
        }

        private static TreeAssignmentResponse ToResponse(TreeAssignment assignment)
        {
            return new TreeAssignmentResponse
            {
                Id = assignment.ID,

                DonationId = assignment.DONATIONID,

                DonorId = assignment.Donation?.DONORID,
                DonorName = assignment.Donation?.Donor?.FULLNAME,

                CampaignId = assignment.Donation?.CAMPAIGNID,
                CampaignName = assignment.Donation?.Campaign?.NAME,

                DonationAmount = assignment.Donation?.AMOUNT ?? 0,

                Status = assignment.STATUS.ToString(),

                Remarks = assignment.REMARKS,

                CreatedDate = assignment.CREATEDDATE
            };
        }
    }
}
