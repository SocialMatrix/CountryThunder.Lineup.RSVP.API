using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryThunder.Lineup.RSVP.API.Controllers;
using CountryThunder.Lineup.RSVP.API.Interfaces;
using CountryThunder.Lineup.RSVP.API.Protos;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CountryThunder.Lineup.RSVP.API.Services
{
    public class RSVPService : RSVPPostService.RSVPPostServiceBase, IRSVPService
    {
        private readonly ILogger<RSVPService> _logger;

        private readonly IRSVPRepository _rsvpRepository;

        public RSVPService(ILogger<RSVPService> logger, IRSVPRepository rsvpRepository)
        {
            _logger = logger;
            _rsvpRepository = rsvpRepository;
        }

        public override async Task<RSVPPostResponse> RSVPPost(RSVPPostRequest request, ServerCallContext context)
        {
            try
            {
                if (request != null)
                {
                    var rsvpAdded = await _rsvpRepository.InsertRSVP(new Data.RSVP(){Attendee = request.Attendee, Id = request.Id, Lineup = request.Lineup});

                    return await Task.FromResult(new RSVPPostResponse{ Attendee = rsvpAdded.Attendee, Id = rsvpAdded.Id, Lineup = rsvpAdded.Lineup });
                }
                else
                {
                    return await Task.FromResult(new RSVPPostResponse{});
                }
                
            }
            catch (Exception exception)
            {
                return await Task.FromResult(new RSVPPostResponse { });
            }
        }
    }
}
