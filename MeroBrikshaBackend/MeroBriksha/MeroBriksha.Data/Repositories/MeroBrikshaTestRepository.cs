using MeroBriksha.Core.Entities;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Repositories
{
    public class MeroBrikshaTestRepository : IMeroBrikshaTestRepository
    {
        private readonly AppDbContext _context;

        public MeroBrikshaTestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> TestDBConnectionAsync()
        {
            bool canConnect = await _context.Database.CanConnectAsync();
            return canConnect;
        }

    }
}
