using MeroBriksha.Services.DTOs.DonorDtos;
using MeroBriksha.Services.DTOs.Donors;

namespace MeroBriksha.Services.Interfaces
{
    public interface IDonorService
    {
        Task<List<DonorResponse>> GetAllDonorsAsync();
        Task<DonorResponse> CreateDonorAsync(CreateDonorRequest request);
    }
}