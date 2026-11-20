# Petstore API tests

Automated API tests for the public [Swagger Petstore](https://petstore.swagger.io/) service, written in C# with Reqnroll and MSTest.

The suite covers creating pets with varied field values, retrieving created pets, deleting them, and handling unknown pet IDs. Scenarios for invalid path IDs and zero or negative submitted IDs document known differences between the public demo server and the test case expectations; they are marked `@ignore` and do not fail CI. The suite does not claim full Petstore coverage.

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
| `Api/Petstore.Api.Tests.Tests` | Reqnroll scenarios, step definitions, and assertions |
| `Api/Petstore.Api.Tests.Data` | Test data and pet builder |
| `Api/Petstore.Api.Tests.Services` | Petstore HTTP client and service methods |
| `Api/Petstore.Api.Tests.Infrastructure` | Test configuration |
| `Api/AppDtos` | Request and response DTOs |
