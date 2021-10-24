using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CountryThunder.Lineup.RSVP.API.Interfaces
{
    public interface IRSVPRepository
    {
        Task<IEnumerable<Data.RSVP>> GetRSVPs();

        Task<Data.RSVP> InsertRSVP(Data.RSVP rsvp);
        Task<Data.RSVP> GetRSVP(int id);
    }
}
