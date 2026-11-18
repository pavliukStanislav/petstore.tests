using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Petstore.Api.Services.Http;
using Petstore.Api.Tests.Infrastructure.Configuration;

namespace Petstore.Api.Services.Pets;

internal class PetstoreRequestBuilder
{
    private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    private static readonly IApiClient _petstoreClient = new ApiClient(new() { BaseAddress = ApiTestSettings.PetstoreBaseUrl }, _loggerFactory.CreateLogger<ApiClient>());

    private readonly HttpRequestMessage _request = new();

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
        _request.Content = JsonContent.Create(body);
        return this;
    }

    public async Task<ApiResponse<TResponse>> SendAsync<TResponse>(CancellationToken cancellationToken = default)
    {
        using (_request)
        {
            _request.Headers.Accept.ParseAdd("application/json");
            return await _petstoreClient.SendAsync<TResponse>(_request, cancellationToken);
        }
    }
}
