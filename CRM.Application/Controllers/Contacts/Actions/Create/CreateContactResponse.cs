namespace CRM.Application.Controllers.Contacts.Actions.Create
{
    using Api.Responses.Abstractions;

    public class CreateContactResponse : IResponse
    {
        public long Id { get; set; }
    }
}