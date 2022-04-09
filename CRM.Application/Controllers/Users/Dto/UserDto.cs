using CRM.Domain.Users.Enums;

namespace CRM.Application.Controllers.Users.Dto
{
    public class UserDto
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string Email { get ; set; }

        public UserRoles UserRole { get; set; }

        public bool IsBlocked { get; set; }
    }
}
