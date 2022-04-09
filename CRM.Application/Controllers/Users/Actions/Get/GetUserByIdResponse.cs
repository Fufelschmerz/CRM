namespace CRM.Application.Controllers.Users.Actions.Get
{
    using Api.Responses.Abstractions;
    using CRM.Application.Controllers.Users.Dto;

    public class GetUserByIdResponse : IResponse
    {
        public UserDto User { get; set; }
    }
}
