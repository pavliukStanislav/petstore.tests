using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Petstore.Api.Tests.Services.Http;
using Petstore.Api.Tests.Infrastructure.Configuration;

namespace Petstore.Api.Tests.Services.Pets;

public class PetstoreRequestBuilder(Action<string>? testOutput)
{
    private static readonly IApiClient _petstoreClient = new ApiClient(new() { BaseAddress = ApiTestSettings.PetstoreBaseUrl });

    private readonly HttpRequestMessage _request = new();
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public PetstoreRequestBuilder WithMethod(HttpMethod method)
    {
        _request.Method = method;
        return this;
    }

    public PetstoreRequestBuilder WithUrl(string url)
    {
        _request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
        return this;
    }

    public PetstoreRequestBuilder WithJsonBody<T>(T body)
    {
        _request.Content = JsonContent.Create(body, options: _jsonOptions);
        return this;
    }

    public async Task<ApiResponse<TResponse>> SendAsync<TResponse>(CancellationToken cancellationToken = default)
    {
        using (_request)
        {
            if (_request.Headers.Accept.Count == 0)
            {
                _request.Headers.Accept.ParseAdd("application/json");
            }

            return await _petstoreClient.SendAsync<TResponse>(_request, cancellationToken, testOutput);
        }
    }
}
