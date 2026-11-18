using AppDtos.Pets.Requests;

namespace Petstore.Api.Tests.Data.Pets;

public static class PetTestData
{
    public static CreatePetRequestDto CreateValidPet()
    {
        var name = $"test-pet-{Guid.NewGuid():N}";

        return new PetBuilder()
            .WithName(name)
            .WithPhotoUrls($"https://example.com/pets/{name}.jpg")
            .WithStatus("available")
            .Build();
    }
}
