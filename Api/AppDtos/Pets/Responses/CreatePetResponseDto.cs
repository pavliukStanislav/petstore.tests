namespace AppDtos.Pets.Responses;

public class CreatePetResponseDto : IPetDto
{
    public string Name { get; set; } = string.Empty;

    public List<string> PhotoUrls { get; set; } = [];

    public Int128? Id { get; set; }

    public CategoryDto? Category { get; set; }

    public List<TagDto>? Tags { get; set; }

    public string? Status { get; set; }
}
