﻿using CountryThunder.Lineup.RSVP.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryThunder.Lineup.RSVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController : ControllerBase
    {
        private readonly IRSVPRepository _rsvpRepository;

        public RSVPController(IRSVPRepository rsvpRepository)
        {
            _rsvpRepository = rsvpRepository;
        }

        // GET: api/<RSVPController>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _rsvpRepository.GetRSVPs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/<RSVPController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Data.RSVP>> GetAsync(int id)
        {
            try
            {
                var result = await _rsvpRepository.GetRSVP(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<RSVPController>
        [HttpPost]
        public async Task<ActionResult<Data.RSVP>> PostAsync([FromBody] Data.RSVP rsvp)

        {
            try
            {
                if (rsvp == null)
                    return BadRequest();

                var rsvpCreated = await _rsvpRepository.InsertRSVP(rsvp);

                return Created(rsvpCreated.Id.ToString(), rsvpCreated);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    exception.Message);
            }
        }

        // PUT api/<RSVPController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RSVPController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
