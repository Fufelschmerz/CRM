using CRM.Domain.Users.Enums;

namespace CRM.Application.Controllers.Users.Actions.GetList
{
    public class GetUserListFilter
    {
        public UserRoles? Role { get; set; }

        public bool? IsBlocked { get; set; }

        public string Search { get; set; }
    }
}
