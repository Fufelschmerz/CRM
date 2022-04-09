using Api.Responses.Abstractions;
using CRM.Application.Controllers.States.Dto;

namespace CRM.Application.Controllers.States.Actions.Get
{
    public class GetStateByIdResponse :IResponse
    {
        public StateDto StateDto { get; set; }
    }
}
