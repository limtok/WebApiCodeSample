using Agency.Api.Controllers.Agency.Dto;
using AutoMapper;

namespace Agency.Api.Controllers.Mapper
{
    public class AgencyProfile : Profile
    {
        public AgencyProfile()
        {
            CreateMap<Core.Agency, AgencyDto>();
        }
    }
}
