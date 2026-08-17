using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.DBContext
{
    public class SqlServerDbContext : AppDbContext
    {
        public SqlServerDbContext(
            DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {
        }
    }
}
