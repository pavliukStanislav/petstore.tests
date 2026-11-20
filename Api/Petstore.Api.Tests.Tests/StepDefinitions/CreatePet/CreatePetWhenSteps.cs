using Petstore.Api.Tests.Services.Pets;
using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;

namespace Petstore.Api.Tests.Tests.StepDefinitions.CreatePet;

[Binding]
public class CreatePetWhenSteps(PetContext context, ApiResponseMetadataContext responseMetadata, PetsService pets)
{
    [When("I create the pet")]
    public async Task WhenICreateThePet()
    {
        var responce = await pets.CreatePetAsync(context.CreatePetRequest);
        context.CreatePetResponse = responce.Body!;
        responseMetadata.StatusCode = responce.StatusCode;
    }
}
