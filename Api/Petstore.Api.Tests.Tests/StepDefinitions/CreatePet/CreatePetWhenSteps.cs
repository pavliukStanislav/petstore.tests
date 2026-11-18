using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;
using Petstore.Api.Services.Pets;

namespace Petstore.Api.Tests.Tests.StepDefinitions.CreatePet;

[Binding]
public class CreatePetWhenSteps(CreatePetContext context, PetsService pets)
{
    [When("I create the pet")]
    public async Task WhenICreateThePet()
    {
        context.Response = await pets.CreatePetAsync(context.SubmittedPet);
    }
}
