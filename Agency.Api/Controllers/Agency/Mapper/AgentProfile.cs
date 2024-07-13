using Agency.Api.Controllers.Agency.Dto;
using AutoMapper;

namespace Agency.Api.Controllers.Mapper
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<Core.Agent, AgentDto>();
            CreateMap<CreateAgentDto, Core.Agent>();
        }
    }
}
