using Api.Responses.Abstractions;

namespace CRM.Application.Controllers.Accounts.Actions.Authorization
{
    public class AuthorizationResponse : IResponse
    {
        public AuthorizationResponse(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }

        public bool IsAuthorized { get; }
    }
}