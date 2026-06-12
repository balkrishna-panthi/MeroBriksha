using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.Interfaces
{
    public interface IMeroBrikshaTestRepository
    {
        Task<bool> TestDBConnectionAsync();
    }
}
