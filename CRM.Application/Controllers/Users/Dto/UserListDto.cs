using CRM.Domain.Users.Enums;

namespace CRM.Application.Controllers.Users.Dto
{
    public class UserListDto
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public UserRoles UserRole { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }
    }
}