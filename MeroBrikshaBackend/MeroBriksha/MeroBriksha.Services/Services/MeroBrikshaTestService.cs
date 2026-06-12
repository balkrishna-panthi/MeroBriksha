using MeroBriksha.Data.DBContext;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    internal class MeroBrikshaTestService : IMeroBrikshaTestService
    {
        private readonly IMeroBrikshaTestRepository _testRepository;

        public MeroBrikshaTestService(IMeroBrikshaTestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<bool> TestDBConnectionAsync()
        {
            bool canConnect = await _testRepository.Database.CanConnectAsync();
            return canConnect;
        }
    }
}
