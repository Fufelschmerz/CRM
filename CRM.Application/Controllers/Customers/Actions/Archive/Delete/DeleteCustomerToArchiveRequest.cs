namespace CRM.Application.Controllers.Customers.Actions.Archive.Delete
{
    using Api.Requests.Abstractions;
    using FluentValidation;


    public class DeleteCustomerToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteCustomerToArchiveRequestValidator : AbstractValidator<DeleteCustomerToArchiveRequest>
    {
        public DeleteCustomerToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}