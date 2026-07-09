using MeroBriksha.Core.Entities;
using MeroBriksha.Core.ReadModels;
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
        return await _context.Donations.AsNoTracking()
            .Include(x => x.Donor)
            .Include(x => x.Campaign)
            .FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<List<Donation>> GetAllAsync()
    {
        return await _context.Donations.AsNoTracking()  
            .Include(x => x.Donor)
            .Include(x => x.Campaign)
            .OrderByDescending(x => x.CREATEDDATE)
            .ToListAsync();
    }
    public async Task<CampaignDonationTotalReadModel> TotalDonationByCampaignIdAsync(string id)
    {// NOTE:
     // _context.Donations inside this projection does not execute a separate database query.
     // EF Core builds one SQL command when FirstOrDefaultAsync() is called.
     // Sum() and Count() are translated into SQL aggregate subqueries, so this returns
     // campaign details, total donation amount, and donation count in a single DB round trip.
        
        var campaignDonation = await _context.Campaigns
                                .AsNoTracking()
                                .Where(c => c.ID == id)
                                .Select(c => new CampaignDonationTotalReadModel
                                {
                                    CampaignId = c.ID,
                                    CampaignName = c.NAME,

                                    TotalAmount = _context.Donations.AsNoTracking()
                                        .Where(d => d.CAMPAIGNID == c.ID)
                                        .Select(d => (decimal?)d.AMOUNT)
                                        .Sum() ?? 0,
                                    DonationCount = _context.Donations.AsNoTracking()
                                        .Where(d => d.CAMPAIGNID == c.ID)
                                        .Count()
                                })
                                .FirstOrDefaultAsync();

        return campaignDonation;
    }
    public Task<List<CampaignDonationTotalReadModel>> TotalDonationPerCampaignAsync()
    {
        var campaignDonations = _context.Campaigns
                                .AsNoTracking()                                
                                .Select(c => new CampaignDonationTotalReadModel
                                {
                                    CampaignId = c.ID,
                                    CampaignName = c.NAME,
                                    TotalAmount = _context.Donations.AsNoTracking()
                                        .Where(d => d.CAMPAIGNID == c.ID)
                                        .Select(d => (decimal?)d.AMOUNT)
                                        .Sum() ?? 0,
                                    DonationCount = _context.Donations.AsNoTracking()
                                        .Where(d => d.CAMPAIGNID == c.ID)
                                        .Count()
                                })
                                .ToListAsync();
        return campaignDonations;
    }

    public async Task<decimal> GetTotalAsync()
    {
        var totalAmount = await _context.Donations.AsNoTracking()
        .SumAsync(x => (decimal?)x.AMOUNT) ?? 0;

        return totalAmount;
       
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