namespace CRM.Application.Controllers.States.Actions.Create
{
    using Api.Responses.Abstractions;

    public class CreateStateResponse : IResponse
    {
        public long Id { get; set; }
    }
}