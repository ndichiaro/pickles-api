using Microsoft.AspNetCore.Mvc;
using Pickles.Api.Models;
using Pickles.Data;
using System.Linq;
using Pickles.Data.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pickles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        #region Variables
        private readonly PickleContext _context;
        #endregion

        #region Constructors
        public VotesController(PickleContext context)
        {
            _context = context;
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

        /// <summary>
        /// Gets all the votes
        /// </summary>
        /// <returns>a list of votes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var votes = new List<VoteApiModel>();
            var votesData = _context.Votes
                                    .Include(x => x.Voter)
                                    .Include(x => x.Type);

            foreach (var item in votesData)
            {
                var vote = new VoteApiModel
                {
                    PickleTypeId = item.Type.Id,
                    FirstName = item.Voter.FirstName,
                    LastName = item.Voter.LastName,
                    Email = item.Voter.Email,
                    Latitute = item.Voter.Latitute,
                    Longitude = item.Voter.Longitude,
                    ZipCode = item.Voter.ZipCode
                };

                votes.Add(vote);
            }
            return Ok(votes);
        }
        #endregion
    }
}
