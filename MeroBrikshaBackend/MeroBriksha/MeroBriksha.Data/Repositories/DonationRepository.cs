using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeroBriksha.Data.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly AppDbContext _context;

    public DonationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Donation?> GetByIdAsync(string id)
    {
        return await _context.Donations
            .Include(x => x.Donor)
            .Include(x => x.Campaign)
            .FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<List<Donation>> GetAllAsync()
    {
        return await _context.Donations
            .Include(x => x.Donor)
            .Include(x => x.Campaign)
            .OrderByDescending(x => x.CREATEDDATE)
            .ToListAsync();
    }
    public async Task<List<DonationByCampaignIdResponse>> GroupByCampaignIDAsync()
    {
        return await _context.Donations
        .GroupBy(x => x.CAMPAIGNID)
        .ToListAsync();
    }

    public async Task<List<Donation>> GetTotalAsync()
    {
        return await _context.Donations
            .Include(x => x.Donor)
            .Include(x => x.Campaign)
            .OrderByDescending(x => x.CREATEDDATE)
            .ToListAsync();
    }


    public async Task AddAsync(Donation donation)
    {
        await _context.Donations.AddAsync(donation);
    }

    public void Update(Donation donation)
    {
        _context.Donations.Update(donation);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}