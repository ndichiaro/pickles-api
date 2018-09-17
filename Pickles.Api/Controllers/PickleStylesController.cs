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
    public class PickleStylesController : ControllerBase
    {
        #region Variables
        private readonly PickleContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public PickleStylesController(PickleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Gets all pickle styles
        /// </summary>
        /// <returns>a list of pickle styles</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PickleStyleApiModel>> Get()
        {
            var pickleStyles = _context.PickleStyles.ToList();
            return _mapper.Map<List<PickleStyleApiModel>>(pickleStyles);
        }

        /// <summary>
        /// Gets a specific pickle style by it's id
        /// </summary>
        /// <param name="id">the pickle style id</param>
        /// <returns>a pickle style</returns>
        [HttpGet("{id}")]
        public ActionResult<PickleStyleApiModel> Get(int id)
        {
            var pickleStyle = _context.PickleStyles.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<PickleStyleApiModel>(pickleStyle);
        }
        #endregion
    }
}