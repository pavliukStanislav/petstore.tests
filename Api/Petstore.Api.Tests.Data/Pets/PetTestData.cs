using AppDtos.Pets;
using AppDtos.Pets.Requests;
using System.Xml.Linq;

namespace Petstore.Api.Tests.Data.Pets;

public static class PetTestData
{
    public static CreatePetRequestDto CreateValidPetWithRandomFields()
    {
        var name = $"test-pet-{Guid.NewGuid():N}";

        return new PetBuilder()
            .WithName(name)
            .WithId(Random.Shared.NextInt64(1, Int64.MaxValue))
            .WithPhotoUrls($"https://example.com/pets/{name}.jpg")
            .WithStatus("available")
            .Build();
    }

    public static CreatePetRequestDto CreatePetwWithRequiredFieldsOnly(string name, params List<string> photoUrls) =>
        new PetBuilder()
            .WithName(name)
            .WithPhotoUrls(photoUrls)
            .Build();

    public static CreatePetRequestDto CreatePetWithPhonosOnly(params List<string> photoUrls) =>
        new PetBuilder()
            .WithPhotoUrls(photoUrls)
            .Build();

    public static CreatePetRequestDto CreatePetWithNameOnly(string name) =>
        new PetBuilder()
            .WithName(name)
            .Build();
    
    public static CreatePetRequestDto CreatePetWithFields(
        string id, string category, string name, string photoUrls, string tags, string status)
    {
        var uniqueName = $"test-pet-{Guid.NewGuid():N}";
        var builder = new PetBuilder()
            .WithName(name switch
            {
                "ordinary" => uniqueName,
                "long" => uniqueName + new string('x', 1003),
                "unicode" => uniqueName + "-фів-🐈", // name with Unicode characters
                "empty" => string.Empty,
                _ => throw new ArgumentOutOfRangeException(nameof(name))
            })
            .WithPhotoUrls(photoUrls switch
            {
                "empty" => [],
                "one" => [$"https://asdwada.com/{uniqueName}.jpg"],
                "two" => [
                    $"https://hd65y63.com/{uniqueName}-1.jpg",
                    $"https://asdwada.com/{uniqueName}.jpg"],
                "not-url" => ["grserer034t348-rwer0-w"],
                _ => throw new ArgumentOutOfRangeException(nameof(photoUrls))
            })
            .WithCategory(category switch
            {
                "absent" => null,
                "empty" => new CategoryDto(),
                "partial" => new CategoryDto { Name = "some-category" },
                "full" => new CategoryDto { Id = 101, Name = "some-category" },
                _ => throw new ArgumentOutOfRangeException(nameof(category))
            })
            .WithTags(tags switch
            {
                "absent" => null,
                "empty" => [],
                "one" => [new TagDto { Id = 201, Name = "someTag" }],
                "two" => [
                    new TagDto { Id = 201, Name = "someTag" },
                    new TagDto { Id = 202, Name = "tag-two" }],
                "without-id" => [new TagDto { Id = 0, Name = "tag-one" }],
                _ => throw new ArgumentOutOfRangeException(nameof(tags))
            });

        if (id != "absent")
        {
            builder.WithId(Random.Shared.NextInt64(1, Int64.MaxValue));
        }

        if (status != "absent")
        {
            builder.WithStatus(status);
        }

        return builder.Build();
    }
}
