using AppDtos.Pets;
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

    public PetBuilder WithPhotoUrls(params List<string> photoUrls)
    {
        _pet.PhotoUrls = photoUrls;
        return this;
    }

    public PetBuilder WithStatus(string status)
    {
        _pet.Status = status;
        return this;
    }

    public PetBuilder WithId(Int128? id)
    {
        _pet.Id = id;
        return this;
    }

    public PetBuilder WithCategory(CategoryDto? category)
    {
        _pet.Category = category;
        return this;
    }

    public PetBuilder WithTags(List<TagDto> tags)
    {
        _pet.Tags = tags;
        return this;
    }

    public CreatePetRequestDto Build() => _pet;
}
