using AutoMapper;

namespace Agency.Application.Mapper
{
    public class AgencyProfile : Profile
    {
        public AgencyProfile()
        {
            CreateMap<Core.Agency, AgencyElement>()
                .ReverseMap();
        }
    }
}
