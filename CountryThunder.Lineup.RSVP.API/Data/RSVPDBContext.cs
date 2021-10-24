using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CountryThunder.Lineup.RSVP.API.Data
{
    public class RSVPDBContext : DbContext
    {
        public DbSet<RSVP> RSVPs { get; set; }

        public RSVPDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
