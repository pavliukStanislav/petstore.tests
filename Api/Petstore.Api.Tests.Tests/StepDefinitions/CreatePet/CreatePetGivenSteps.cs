using AppDtos.Pets;
using AppDtos.Pets.Requests;
using AppDtos.Pets.Responses;
using Petstore.Api.Tests.Data.Pets;
using Petstore.Api.Tests.Services.Http;
using Petstore.Api.Tests.Services.Pets;
using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;

namespace Petstore.Api.Tests.Tests.StepDefinitions.CreatePet;

[Binding]
public class CreatePetGivenSteps(PetContext context, PetsService pets)
{
    [Given("a new pet is prepared and created")]
    public async Task GivenANewPetIsCreated()
    {
        var (pet, created) = await CreatePetAsync();
        context.CreatePetRequest = pet;
        context.CreatePetResponse = created.Body!;
    }

    [Given("two new pets are created")]
    public async Task GivenTwoNewPetsAreCreated()
    {
        var (pet, created) = await CreatePetAsync();
        context.CreatePetRequest = pet;
        context.CreatePetResponse = created.Body!;

        var (pet2, created2) = await CreatePetAsync();
        context.CreatePetRequest2 = pet2;
        context.CreatePetResponse2 = created2.Body!;
    }

    [Given("a pet with no name with photo URL {string}")]
    public void GivenAPetWithNoNameWithPhotoURL(string photoUrl)
    {
        context.CreatePetRequest = PetTestData.CreatePetWithPhonosOnly(photoUrl);
    }

    [Given("a pet named {string} without photo URL")]
    public void GivenAPetNamedWithoutPhotoURL(string name)
    {
        context.CreatePetRequest = PetTestData.CreatePetWithNameOnly(name);
    }


    [Given("pet data with {string}, {string}, {string}, {string}, {string} and {string}")]
    public void GivenPetDataWith(string id, string category, string name, string photoUrls, string tags, string status)
    {
        context.CreatePetRequest = PetTestData.CreatePetWithFields(id, category, name, photoUrls, tags, status);
    }

    [Given("a pet named {string} with photo URL {string}")]
    public void GivenAPetNamedTest_Pet_Id_WithPhotoURL(string name, string url)
    {
        context.CreatePetRequest = PetTestData.CreatePetwWithRequiredFieldsOnly(name, url);
    }

    [Given("another photo URL {string}")]
    public void GivenAnotherPhotoUrl(string photoUrl) =>
        context.CreatePetRequest.PhotoUrls.Add(photoUrl);

    [Given("its ID is {string}")]
    public void GivenItsIdIs(string id) => context.CreatePetRequest.Id = Int128.Parse(id);

    [Given("its status is {string}")]
    public void GivenItsStatusIs(string status) => context.CreatePetRequest.Status = status;

    [Given("its category ID is {string}")]
    public void GivenItsCategoryIdIs(string id) =>
        context.CreatePetRequest.Category = new CategoryDto { Id = Int128.Parse(id) };

    [Given("its category is named {string}")]
    public void GivenItsCategoryIsNamed(string name) =>
        context.CreatePetRequest.Category = new CategoryDto { Name = name };

    [Given("its category is named {string} with ID {string}")]
    public void GivenItsCategoryIsNamedWithId(string name, string id) =>
        context.CreatePetRequest.Category = new CategoryDto { Id = Int128.Parse(id), Name = name };

    [Given("it has a tag with ID {string}")]
    public void GivenItHasATagWithId(string id) =>
        context.CreatePetRequest.Tags = [new TagDto { Id = Int128.Parse(id) }];

    [Given("it has an empty tag")]
    public void GivenItHasAnEmptyTag() => context.CreatePetRequest.Tags = [new TagDto { Id = 0, Name = ""}];

    [Given("it has a tag named {string}")]
    public void GivenItHasATagNamed(string name) =>
        context.CreatePetRequest.Tags = [new TagDto { Id = 0, Name = name }];

    [Given("it has a tag named {string} with ID {string}")]
    public void GivenItHasATagNamedWithId(string name, string id) =>
        context.CreatePetRequest.Tags = [new TagDto { Id = Int128.Parse(id), Name = name }];

    private async Task<(CreatePetRequestDto Pet, ApiResponse<CreatePetResponseDto> Created)> CreatePetAsync()
    {
        var pet = PetTestData.CreateValidPetWithRandomFields();
        var created = await pets.CreatePetAsync(pet);

        return (pet, created);
    }
}
