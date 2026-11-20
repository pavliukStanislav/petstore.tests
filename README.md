# Petstore API tests

API tests for the public [Swagger Petstore](https://petstore.swagger.io/) `/v2/pet` endpoints. The suite uses .NET 10, C#, Reqnroll, and MSTest.

## Coverage

| Endpoint | Scenarios |
| --- | --- |
| `POST /pet` | Create pets with different combinations of fields; verify the create response and retrieve the created pet. Additional cases cover required fields, category and tag IDs, repeated photo URLs, Unicode, negative and maximum 64-bit IDs, and an ID outside the 64-bit range. |
| `GET /pet/{petId}` | Retrieve created pets; check unknown, nonnumeric, fractional, and out-of-range IDs. |
| `DELETE /pet/{petId}` | Delete a pet and verify it is gone; verify another pet remains available; check unknown and invalid IDs. |

The negative creation scenarios also check requests missing a name or photo URLs. IDs in the request and response DTOs use `Int128` so the suite can send a value outside the API's 64-bit ID range.

Some scenarios document behavior that differs from their expected result on the public demo API and may fail. For example, the out-of-range `POST /pet` scenario expects HTTP 400; a comment in the feature file records HTTP 500 as the demo API's response. These scenarios are not skipped.

## Further coverage

Time constraints left the following cases and improvements for future work:

- **Request validation:** invalid types and oversized values for `category`, `name`, and `photoUrls`; boundary values `0` and `1` and invalid types for `pet.id`; the same ID cases for `category.id`; validation of other fields and nested properties. The suite already sends a long name, but does not check a defined maximum length.
- **Request behavior:** create a pet with an ID already in use; recreate a previously deleted pet; send an incorrect `Content-Type`; check `DELETE /pet/{petId}` with a valid, invalid, or missing `api_key` header.
- **Response checks:** verify relevant headers in addition to the status code. Make assertions specific to each scenario so they do not depend on conditional branches for different inputs.
- **Framework:** extend the test infrastructure as coverage grows, including more flexible request construction and, where needed, support for mocks and other test dependencies. Consider injecting Reqnroll's `ScenarioContext` as a simple way to share data between steps, provided it preserves scenario isolation and does not make the tests less stable.

## Run locally

Install the .NET 10 SDK and make sure the public Petstore API is reachable. From the repository root:

```powershell
dotnet test .\Api\Petstore.Api.Tests.slnx --settings .\Api\ApiTests.runsettings
```

The test URL is configured as `PETSTORE_BASE_URL` in [ApiTests.runsettings](Api/ApiTests.runsettings); its default is `https://petstore.swagger.io/v2/`.

Up to three feature files run in parallel; scenarios within each feature run sequentially.

## HTML report

To generate and open the Reqnroll report locally:

```powershell
$env:REQNROLL_FORMATTERS_HTML = 'outputFilePath=reqnroll_report.html'
dotnet test .\Api\Petstore.Api.Tests.slnx --settings .\Api\ApiTests.runsettings
Invoke-Item .\Api\Petstore.Api.Tests.Tests\bin\Debug\net10.0\reqnroll_report.html
```

## GitHub Actions

The [API tests workflow](.github/workflows/api-tests.yml) runs on every pull request and can also be started manually. To view a report, open a run on the repository's [Actions page](https://github.com/pavliukStanislav/petstore.tests/actions), then use the report link in the run summary or download the `reqnroll-report` artifact. Manual runs on `main` also publish an online report to GitHub Pages; its link appears in the run summary.

## Project layout

| Directory | Contents |
| --- | --- |
| `Api/Petstore.Api.Tests.Tests` | Reqnroll feature files, step definitions, assertions, and scenario contexts |
| `Api/Petstore.Api.Tests.Data` | Pet test data and builder |
| `Api/Petstore.Api.Tests.Services` | HTTP client and Petstore service methods |
| `Api/Petstore.Api.Tests.Infrastructure` | Base URL configuration |
| `Api/AppDtos` | Pet request and response DTOs |
