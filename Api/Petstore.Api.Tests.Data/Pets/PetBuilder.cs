using AppDtos.Pets.Requests;

namespace Petstore.Api.Tests.Data.Pets;

internal class PetBuilder
{
    private readonly CreatePetRequestDto _pet = new();

    public PetBuilder WithName(string name)
    {
        _pet.Name = name;
        return this;
    }

    public PetBuilder WithPhotoUrls(params string[] photoUrls)
    {
        _pet.PhotoUrls = photoUrls;
        return this;
    }

    public PetBuilder WithStatus(string status)
    {
        _pet.Status = status;
        return this;
    }

    public CreatePetRequestDto Build() => _pet;
}
