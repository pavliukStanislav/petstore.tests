namespace AppDtos.Pets.Requests;

public class CreatePetRequestDto : IPetDto
{
    public string Name { get; set; } = string.Empty;

    public List<string> PhotoUrls { get; set; } = [];

    public Int128? Id { get; set; }

    public CategoryDto? Category { get; set; }

    public List<TagDto>? Tags { get; set; } = [];

    public string? Status { get; set; }
}
