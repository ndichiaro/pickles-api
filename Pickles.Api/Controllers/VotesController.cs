using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pickles.Api.Models;
using Pickles.Data;
using System.Collections.Generic;

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
        [HttpPost]
        public IActionResult Post([FromBody] VoteApiModel vote)
        {
            return Ok();
        }
        #endregion
    }
}
