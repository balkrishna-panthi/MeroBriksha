using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services
{
    public class MeroBrikshaTestService : IMeroBrikshaTestService
    {
        private readonly IMeroBrikshaTestRepository _testRepository;

        public MeroBrikshaTestService(IMeroBrikshaTestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<bool> TestDBConnectionAsync()
        {
            bool canConnect = await _testRepository.TestDBConnectionAsync();
            return canConnect;
        }
    }
}
