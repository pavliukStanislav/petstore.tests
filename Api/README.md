# Petstore API Tests

Run from the repository root with the .NET 10 SDK or later.

```powershell
dotnet test .\Api\Petstore.Api.Tests.slnx --settings .\Api\ApiTests.runsettings --logger "console;verbosity=detailed"
```

The solution contains five projects.

| Project | Responsibility |
| --- | --- |
| `Petstore.Api.Tests.Tests` | Reqnroll feature files and step definitions, with MSTest as the runner |
| `Petstore.Api.Tests.Data` | Factories for test payloads |
| `Petstore.Api.Tests.Infrastructure` | Loading typed test configuration |
| `AppDtos` | API DTOs |
| `Petstore.Api.Tests.Services` | HTTP transport and endpoint-specific service methods |

The `@api` scenario sends valid pet data to `POST /v2/pet` and verifies HTTP 200, the generated ID, and the submitted fields. `ApiClient` logs the request, status, and response body through `ILogger`, configured with the standard console provider for the test run.

VSTest sets `PETSTORE_BASE_URL` from `ApiTests.runsettings`. `ApiTestSettings` reads it on first access and exposes it as a `Uri` for the Petstore client. To use another Petstore instance, update the URL in the runsettings file, including the version path.

Every pull request runs the tests in GitHub Actions. Open the **API tests** workflow run from the PR checks, then use the report link in the run summary to download the `reqnroll-report` artifact. Extract it and open `reqnroll_report.html` in a browser. The report is uploaded even if the tests fail, provided Reqnroll generated it.
