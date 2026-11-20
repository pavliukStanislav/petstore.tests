using AppDtos.Pets.Requests;
using AppDtos.Pets.Responses;

namespace Petstore.Api.Tests.Tests.Contexts;

public class PetContext
{
    public CreatePetRequestDto CreatePetRequest { get; set; } = null!;
    public CreatePetRequestDto CreatePetRequest2 { get; set; } = null!;
    public CreatePetResponseDto CreatePetResponse { get; set; } = null!;
    public CreatePetResponseDto CreatePetResponse2 { get; set; } = null!;
}
