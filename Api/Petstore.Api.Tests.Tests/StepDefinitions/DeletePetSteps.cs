using Petstore.Api.Tests.Services.Pets;
using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;
using System.Net;

namespace Petstore.Api.Tests.Tests.StepDefinitions;

[Binding]
public class DeleteSteps(PetContext context, ApiResponseMetadataContext responseMetadata, PetsService pets)
{
    [When("I delete the pet")]
    [When("I delete the first pet")]
    public async Task WhenIDeleteThePet()
    {
        var id = context.CreatePetResponse!.Id!.Value;
        var result = await pets.DeletePetAsync(id.ToString());

        Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        Assert.AreEqual("unknown", result.Body!.Type);
        Assert.AreEqual(id.ToString(), result.Body!.Message);
    }

    [Then("the pet is no longer available")]
    public async Task ThenThePetIsNoLongerAvailable()
    {
        var result = await pets.GetPetWithErrorAsync(context.CreatePetRequest.Id!.Value.ToString());

        Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        Assert.AreEqual("error", result.Body!.Type);
        Assert.AreEqual("Pet not found", result.Body!.Message);
    }

    [Then("the second pet can still be retrieved")]
    public async Task ThenTheSecondPetCanStillBeRetrieved()
    {
        var result = await pets.GetPetAsync(context.CreatePetRequest2.Id!.Value.ToString());

        Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        Assert.IsNotNull(result.Body);
        Assert.AreEqual(context.CreatePetRequest2.Id, result.Body.Id);
    }

    [When("I delete an unknown pet")]
    public async Task WhenIDeleteAnUnknownPet()
    {
        responseMetadata.StatusCode = (await pets.DeletePetAsync(0.ToString())).StatusCode;
    }

    [When("I delete a pet using the invalid ID {string}")]
    public async Task WhenIDeleteAPetUsingAnInvalidId(string id)
    {
        responseMetadata.StatusCode = (await pets.DeletePetAsync(id.ToString())).StatusCode;
    }
}
