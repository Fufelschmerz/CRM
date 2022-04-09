namespace CRM.Application.Controllers.ContactPersons.Actions.Archive.Delete
{
    using Api.Requests.Abstractions;

    public class DeleteContactPersonToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }
}