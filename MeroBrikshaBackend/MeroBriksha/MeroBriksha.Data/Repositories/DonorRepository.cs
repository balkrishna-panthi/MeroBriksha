using Microsoft.EntityFrameworkCore;
using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;

namespace MeroBriksha.Data.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _context;

        public DonorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Donor>> GetAllDonorsAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task<Donor> GetDonorByIdAsync(string id)
        {
            var donor = await _context.Donors.FirstOrDefaultAsync(d => d.ID == id);

            return donor;
        }

        public async Task<Donor> CreateDonorAsync(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();

            return donor;
        }

       
    }
}