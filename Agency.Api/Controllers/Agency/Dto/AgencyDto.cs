using System;
using System.Collections.Generic;

namespace Agency.Api.Controllers.Agency.Dto
{
    public class AgencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public List<AgentDto> Agents { get; set; }
    }
}
