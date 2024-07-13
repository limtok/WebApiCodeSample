using System.ComponentModel.DataAnnotations;

namespace Agency.Api.Controllers.Agency.Dto
{
    public class CreateAgentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AgencyId { get; set; }
    }
}
