using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class testDetailContext:DbContext
    {
        public testDetailContext(DbContextOptions<testDetailContext> options) : base(options)
        {

        }

        public DbSet<testDetail> testDetails { get; set; }
    }
}
