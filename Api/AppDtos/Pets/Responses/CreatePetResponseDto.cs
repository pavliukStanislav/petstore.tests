namespace AppDtos.Pets.Responses;

public class CreatePetResponseDto
{
    public string Name { get; set; } = string.Empty;

    public string[] PhotoUrls { get; set; } = [];

    public long? Id { get; set; }

    public CategoryDto? Category { get; set; }

    public TagDto[]? Tags { get; set; }

    public string? Status { get; set; }
}
