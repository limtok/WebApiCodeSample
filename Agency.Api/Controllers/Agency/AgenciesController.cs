using System.Collections.Generic;
using System.Threading.Tasks;
using Agency.Api.Controllers.Agency.Dto;
using Agency.Application;
using Agency.Core;
using Agency.EntityFramework;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Agency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgenciesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IAgencyImpoter _agencyImpoter;
        private readonly ILogger<AgenciesController> _logger;

        public AgenciesController(
            IMapper mapper,
            IRepository repository,
            IAgencyRepository agencyRepository,
            IAgencyImpoter agencyImpoter,
            ILogger<AgenciesController> logger
            )
        {
            _mapper = mapper;
            _repository = repository;
            _agencyRepository = agencyRepository;
            _agencyImpoter = agencyImpoter;
            _logger = logger;
        }

        [HttpGet(Name = nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<AgencyDto>>> GetAll()
        {
            var entities = await _agencyRepository.FindAllAsync();
            var entitiesDtos = _mapper.Map<IList<AgencyDto>>(entities);
            return Ok(entitiesDtos);
        }

        [HttpPost(Name = nameof(AddAgent))]
        public async Task<ActionResult<AgentDto>> AddAgent(CreateAgentDto agent)
        {
            var agency = await _agencyRepository.FindByIdAsync(agent.AgencyId);
            if (agency == null)
            {
                return NotFound();
            }

            var entity = _mapper.Map<Agent>(agent);
            await _repository.CreateAsync(entity);

            var entityDto = _mapper.Map<AgentDto>(entity);
            return Ok(entityDto);
        }

        [HttpPost(Name = nameof(Import))]
        public async Task<ActionResult> Import(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                await _agencyImpoter.ImportZipAsync(stream);
                return Ok();
            }
        }
    }
}
