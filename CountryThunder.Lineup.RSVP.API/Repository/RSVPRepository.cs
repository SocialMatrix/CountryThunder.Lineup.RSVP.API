using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryThunder.Lineup.RSVP.API.Data;
using CountryThunder.Lineup.RSVP.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CountryThunder.Lineup.RSVP.API.Repository
{
    public class RSVPRepository : IRSVPRepository
    {
        private readonly RSVPDBContext _rsvpDBContext;
        private readonly ILogger<RSVPRepository> _logger;

        public RSVPRepository(RSVPDBContext rsvpDBContext, ILogger<RSVPRepository> logger)
        {
            _rsvpDBContext = rsvpDBContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Data.RSVP>> GetRSVPs()
        {
            return await _rsvpDBContext.RSVPs.ToListAsync();
        }

        public async Task<Data.RSVP> InsertRSVP(Data.RSVP rsvp)
        {
            var result = await _rsvpDBContext.RSVPs.AddAsync(rsvp);
            await _rsvpDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Data.RSVP> GetRSVP(int id)
        {
            return await _rsvpDBContext.RSVPs
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
