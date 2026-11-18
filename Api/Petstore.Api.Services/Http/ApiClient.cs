using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Petstore.Api.Services.Http;

public class ApiClient(HttpClient httpClient, ILogger<ApiClient> logger) : IApiClient
{
    public async Task<ApiResponse<TResponse>> SendAsync<TResponse>(
        HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("HTTP {Method} {Uri}", request.Method, request.RequestUri);
        if (request.Content is not null)
        {
            logger.LogInformation("Request body: {Body}", await request.Content.ReadAsStringAsync(cancellationToken));
        }

        using var response = await httpClient.SendAsync(request, cancellationToken);
        var rawBody = await response.Content.ReadAsStringAsync(cancellationToken);

        logger.LogInformation("HTTP {StatusCode}", (int)response.StatusCode);
        logger.LogInformation("Response body: {Body}", rawBody);

        return new ApiResponse<TResponse>
        {
            StatusCode = response.StatusCode,
            Body = JsonSerializer.Deserialize<TResponse>(rawBody, JsonSerializerOptions.Web)
        };
    }
}
