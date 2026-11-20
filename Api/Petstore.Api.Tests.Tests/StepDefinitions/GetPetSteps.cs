using Petstore.Api.Tests.Services.Pets;
using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;

namespace Petstore.Api.Tests.Tests.StepDefinitions;

[Binding]
public class GetPetSteps(ApiResponseMetadataContext responseMetadata, PetsService pets)
{
    [When("I retrieve an unknown pet")]
    public async Task WhenIRetrieveAnUnknownPet()
    {
        var result = await pets.GetPetWithErrorAsync(0.ToString());

        Assert.AreEqual("error", result.Body!.Type);
        Assert.AreEqual("Pet not found", result.Body!.Message);

        responseMetadata.StatusCode = result.StatusCode;
    }

    [When("I retrieve a pet using the invalid ID {string}")]
    public async Task WhenIRetrieveAPetUsingAnInvalidId(string id)
    {
        var result = await pets.GetPetWithErrorAsync(id);

        Assert.AreEqual("unknown", result.Body!.Type);
        Assert.Contains("NumberFormatException", result.Body!.Message);

        responseMetadata.StatusCode = result.StatusCode;
    }
}
