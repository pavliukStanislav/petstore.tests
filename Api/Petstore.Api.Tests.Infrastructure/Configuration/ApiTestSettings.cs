namespace Petstore.Api.Tests.Infrastructure.Configuration;

public static class ApiTestSettings
{
    public static Uri PetstoreBaseUrl { get; }

    private const string PetstoreBaseUrlVariable = "PETSTORE_BASE_URL";
        
    static ApiTestSettings()
    {
        var baseUrl = Environment.GetEnvironmentVariable(PetstoreBaseUrlVariable)
            ?? throw new InvalidOperationException($"{PetstoreBaseUrlVariable} is missing in ApiTests.runsettings.");

        PetstoreBaseUrl = new Uri(baseUrl.Trim().TrimEnd('/') + "/", UriKind.Absolute);
    }
}
