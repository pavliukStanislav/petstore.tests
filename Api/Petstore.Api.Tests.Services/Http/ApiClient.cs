using System.Text.Json;

namespace Petstore.Api.Tests.Services.Http;

public class ApiClient(HttpClient httpClient) : IApiClient
{
    public async Task<ApiResponse<TResponse>> SendAsync<TResponse>(
        HttpRequestMessage request, CancellationToken cancellationToken = default, Action<string>? testOutput = null)
    {
        testOutput?.Invoke($"HTTP {request.Method} {request.RequestUri}");
        if (request.Content is not null)
        {
            var requestBody = await request.Content.ReadAsStringAsync(cancellationToken);
            testOutput?.Invoke($"Request body: {requestBody}");
        }

        using var response = await httpClient.SendAsync(request, cancellationToken);
        var rawBody = await response.Content.ReadAsStringAsync(cancellationToken);

        testOutput?.Invoke($"HTTP {(int)response.StatusCode}");
        testOutput?.Invoke($"Response body: {rawBody}");

        return new ApiResponse<TResponse>
        {
            StatusCode = response.StatusCode,
            Body = typeof(TResponse) == typeof(string)
                ? (TResponse)(object)rawBody
                : string.IsNullOrWhiteSpace(rawBody)
                    ? default
                    : JsonSerializer.Deserialize<TResponse>(rawBody, JsonSerializerOptions.Web)
        };
    }
}
