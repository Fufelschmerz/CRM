using Api.Responses.Abstractions;

namespace CRM.Application.Controllers.ContactPersons.Actions.Create
{
    public class CreateContactPersonResponse : IResponse
    {
        public long Id { get; set; }
    }
}
