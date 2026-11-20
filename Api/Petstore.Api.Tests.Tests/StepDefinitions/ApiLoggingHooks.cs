using Petstore.Api.Tests.Services.Pets;
using Reqnroll;

namespace Petstore.Api.Tests.Tests.StepDefinitions;

[Binding]
public class ApiLoggingHooks(PetsService pets, IReqnrollOutputHelper output)
{
    [BeforeScenario]
    public void ConfigureApiLogging() => pets.SetTestOutput(output.WriteLine);
}
