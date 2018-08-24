using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pickles.Api.Models;
using Pickles.Data;
using System.Collections.Generic;
using System.Linq;
using Pickles.Data.Models;
using System;

namespace Pickles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        #region Variables
        private readonly PickleContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public VotesController(PickleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Creates a vote for a pickle type
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] VoteApiModel vote)
        {
            // validate pickle type exists
            var pickleType = _context.PickleTypes.FirstOrDefault(x => x.Id == vote.PickleTypeId);
            if (pickleType == null)
            {
                return BadRequest($"{vote.PickleTypeId} is not a valid pickle type.");
            }

            // check if the voter is already in the systems
            var voter = _context.Voters.FirstOrDefault(x => x.Email.Equals(vote.Email, StringComparison.InvariantCultureIgnoreCase));
            if(voter != null && !string.IsNullOrEmpty(vote.Email))
            {
                return Conflict($"The email address {vote.Email} is already associated with a vote.");
            }

            var voteDbObj = new Vote
            {
                PickleTypeId = vote.PickleTypeId,
            };

            var voterDbObj = new Voter
            {
                FirstName = vote.FirstName,
                LastName = vote.LastName,
                Email = vote.Email,
                Latitute = vote.Latitute,
                Longitude = vote.Longitude,
                ZipCode = vote.ZipCode,
                IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                // add the voter
                _context.Voters.Add(voterDbObj);
                _context.SaveChanges();

                // grab the id from the newly saved voter
                voteDbObj.VoterId = voterDbObj.Id;

                // save the vote
                _context.Votes.Add(voteDbObj);
                _context.SaveChanges();

                transaction.Commit();
            }
            return Ok();
        }
        #endregion
    }
}
