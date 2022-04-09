using Api.Responses.Abstractions;

namespace CRM.Application.Controllers.Users.Actions.Create
{
    public class CreateUserResponse : IResponse
    {
        public long Id { get; set; }
    }
}
