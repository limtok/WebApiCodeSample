using AutoMapper;

namespace Agency.Application.Mapper
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<Core.Agent, AgentElement>()
                .ReverseMap();
        }
    }
}
