# Petstore API tests

Automated API tests for the public [Swagger Petstore](https://petstore.swagger.io/) service, written in C# with Reqnroll and MSTest.

The current suite has one scenario: create a pet with valid data using `POST /v2/pet`, then verify HTTP 200, a positive ID, and the submitted name, status, and photo URLs in the response. It is a starting point for additional API scenarios, not full Petstore coverage.

## Run locally

Install the .NET 10 SDK. The tests call a public API, so an internet connection is required.

From the repository root, run:

```powershell
dotnet test .\Api\Petstore.Api.Tests.slnx --settings .\Api\ApiTests.runsettings
```

The default base URL is `https://petstore.swagger.io/v2/`, defined in `Api/ApiTests.runsettings` as `PETSTORE_BASE_URL`. Change that value to test another Petstore instance.

## HTML report

To generate Reqnroll's HTML report during a local run:

```powershell
$env:REQNROLL_FORMATTERS_HTML = 'outputFilePath=reqnroll_report.html'
dotnet test .\Api\Petstore.Api.Tests.slnx --settings .\Api\ApiTests.runsettings
Invoke-Item .\Api\Petstore.Api.Tests.Tests\bin\Debug\net10.0\reqnroll_report.html
```

## Project layout

| Project | Purpose |
| --- | --- |
| `Api/Petstore.Api.Tests.Tests` | Reqnroll scenario, step definitions, and assertions |
| `Api/Petstore.Api.Tests.Data` | Test data and pet builder |
| `Api/Petstore.Api.Tests.Services` | Petstore HTTP client and service methods |
| `Api/Petstore.Api.Tests.Infrastructure` | Test configuration |
| `Api/AppDtos` | Request and response DTOs |
