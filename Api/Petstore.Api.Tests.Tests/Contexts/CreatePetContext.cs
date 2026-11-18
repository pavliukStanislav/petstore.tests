using AppDtos.Pets.Requests;
using AppDtos.Pets.Responses;
using Petstore.Api.Tests.Services.Http;

namespace Petstore.Api.Tests.Tests.Contexts;

public class CreatePetContext
{
    public CreatePetRequestDto SubmittedPet { get; set; } = null!;
    public ApiResponse<CreatePetResponseDto> Response { get; set; } = null!;
}
