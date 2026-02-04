using Services.DTO.Interfaces;

namespace Services.DTO
{
    public class ApplicationUser : IApplicatioUser
    {
        public required string UserName { get; set; }

        public required string Email { get; set; }
    }
}
