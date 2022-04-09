namespace ApiControllers.Abstractions
{
    using Api.Requests.Builders.Abstractions;

    public interface IAsyncApiController
    {
        IAsyncRequestBuilder AsyncRequestBuilder { get; }
    }
}
