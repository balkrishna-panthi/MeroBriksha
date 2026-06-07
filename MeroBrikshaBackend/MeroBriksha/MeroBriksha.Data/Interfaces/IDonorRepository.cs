using MeroBriksha.Core.Entities;

namespace MeroBriksha.Data.Interfaces
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllDonorsAsync();
        Task<Donor> CreateDonorAsync(Donor donor);
    }
}