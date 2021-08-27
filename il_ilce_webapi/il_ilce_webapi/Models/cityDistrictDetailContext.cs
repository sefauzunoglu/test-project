using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace il_ilce_webapi.Models
{
    public class cityDistrictDetailContext : DbContext
    {


        public DbSet<cityDistrict> cityDistricts { get; set; }
    }
}
