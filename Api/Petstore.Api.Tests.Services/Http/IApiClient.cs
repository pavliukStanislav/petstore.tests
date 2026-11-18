namespace Petstore.Api.Tests.Services.Http;

public interface IApiClient
{
    Task<ApiResponse<TResponse>> SendAsync<TResponse>(
        HttpRequestMessage request, CancellationToken cancellationToken = default);
}
