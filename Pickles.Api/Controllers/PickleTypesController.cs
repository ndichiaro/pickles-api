using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pickles.Api.Models;
using Pickles.Data;

namespace Pickles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickleTypesController : ControllerBase
    {
        #region Variables
        private readonly PickleContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public PickleTypesController(PickleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Gets all pickle types
        /// </summary>
        /// <returns>a list of pickle types</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PickleTypeApiModel>> Get()
        {
            var pickleTypes = _context.PickleTypes.ToList();
            return _mapper.Map<List<PickleTypeApiModel>>(pickleTypes);
        }

        /// <summary>
        /// Gets a pickle type
        /// </summary>
        /// <param name="id">the pickle type id</param>
        /// <returns>a pickle</returns>
        [HttpGet("{id}")]
        public ActionResult<PickleTypeApiModel> Get(int id)
        {
            var pickleType = _context.PickleTypes.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<PickleTypeApiModel>(pickleType);
        }
        #endregion
    }
}
