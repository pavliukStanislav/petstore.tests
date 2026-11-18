using Petstore.Api.Tests.Data.Pets;
using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;

namespace Petstore.Api.Tests.Tests.StepDefinitions.CreatePet;

[Binding]
public class CreatePetGivenSteps(CreatePetContext context)
{
    [Given("valid data for a new pet")]
    public void GivenValidDataForANewPet()
    {
        context.SubmittedPet = PetTestData.CreateValidPet();
    }
}
