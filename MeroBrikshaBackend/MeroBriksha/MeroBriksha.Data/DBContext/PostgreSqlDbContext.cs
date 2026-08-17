using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.DBContext
{
    public class PostgreSqlDbContext : AppDbContext
    {
        public PostgreSqlDbContext(
            DbContextOptions<PostgreSqlDbContext> options)
            : base(options)
        {
        }
    }
}
