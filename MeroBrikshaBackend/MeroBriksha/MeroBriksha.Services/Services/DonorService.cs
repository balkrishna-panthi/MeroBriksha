using MeroBriksha.Core.Entities;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.DTOs.DonorDtos;
using MeroBriksha.Services.DTOs.Donors;
using MeroBriksha.Services.Interfaces;

namespace MeroBriksha.Services.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<List<DonorResponse>> GetAllDonorsAsync()
        {
            var donors = await _donorRepository.GetAllDonorsAsync();

            return donors.Select(x => new DonorResponse
            {
                Id = x.ID,
                Fullname = x.FULLNAME,
                Email = x.EMAIL,
                PhoneNumber = x.PHONENUMBER,
                Address = x.ADDRESS,
                CreatedDate = x.CREATEDDATE
            }).ToList();
        }
        public async Task<DonorResponse> GetDonorByIdAsync(string id)
        {
           var donor = await _donorRepository.GetDonorByIdAsync(id);
            if (donor == null)
            {
                return null;
            }
            return new DonorResponse
            {
                Id = donor.ID,
                Fullname = donor.FULLNAME,
                Email = donor.EMAIL,
                PhoneNumber = donor.PHONENUMBER,
                Address = donor.ADDRESS,
                CreatedDate = donor.CREATEDDATE
            };
        }

        public async Task<DonorResponse> CreateDonorAsync(CreateDonorRequest request)
        {
            var donor = new Donor
            {
                ID = Guid.NewGuid().ToString(),
                FULLNAME = request.Fullname,
                EMAIL = request.Email,
                PHONENUMBER = request.PhoneNumber,
                ADDRESS = request.Address,
            };

            var createdDonor = await _donorRepository.CreateDonorAsync(donor);

            return new DonorResponse
            {
                Id = createdDonor.ID,
                Fullname = createdDonor.FULLNAME,
                Email = createdDonor.EMAIL,
                PhoneNumber = createdDonor.PHONENUMBER,
                Address = createdDonor.ADDRESS,
                CreatedDate = createdDonor.CREATEDDATE
            };
        }

        
    }
}