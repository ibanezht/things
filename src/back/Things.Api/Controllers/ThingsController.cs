using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Things.Api.Models;
using Things.Common.Dtos;

namespace Things.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThingsController : ControllerBase
    {
        private readonly ThingsDbContext _db;
        private readonly IMapper _mapper;

        public ThingsController(ThingsDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var retval = _db.Units
                .ProjectTo<ThingDto>(_mapper.ConfigurationProvider)
                .SingleOrDefault(u => u.Id == id);

            if (retval == null)
                return NotFound();

            return Ok(retval);
        }
    }
}