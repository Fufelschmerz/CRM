namespace CRM.Application.Controllers.ContactPersons.Actions.Archive.Add
{
    using Api.Requests.Abstractions;

    public class AddContactPersonToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }
}