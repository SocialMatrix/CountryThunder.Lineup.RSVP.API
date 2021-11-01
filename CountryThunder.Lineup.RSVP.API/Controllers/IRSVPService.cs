using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryThunder.Lineup.RSVP.API.Protos;
using Grpc.Core;

namespace CountryThunder.Lineup.RSVP.API.Controllers
{
    public interface IRSVPService
    {
        Task<RSVPPostResponse> RSVPPost(RSVPPostRequest request, ServerCallContext context);
    }
}
