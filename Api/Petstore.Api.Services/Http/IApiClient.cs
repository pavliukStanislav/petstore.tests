namespace Petstore.Api.Services.Http;

public interface IApiClient
{
    Task<ApiResponse<TResponse>> SendAsync<TResponse>(
        HttpRequestMessage request, CancellationToken cancellationToken = default);
}
