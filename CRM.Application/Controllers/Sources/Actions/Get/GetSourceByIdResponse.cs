namespace CRM.Application.Controllers.Sources.Actions.Get
{
    using Api.Responses.Abstractions;
    using Dto;

    public class GetSourceByIdResponse : IResponse
    {
        public SourceDto Source { get; set; } 
    }
}
