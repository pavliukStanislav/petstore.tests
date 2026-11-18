using AppDtos.Pets.Requests;
using AppDtos.Pets.Responses;
using Petstore.Api.Services.Http;

namespace Petstore.Api.Services.Pets;

public class PetsService
{
    public Task<ApiResponse<CreatePetResponseDto>> CreatePetAsync(
        CreatePetRequestDto petDto, CancellationToken cancellationToken = default)
        => new PetstoreRequestBuilder()
            .WithMethod(HttpMethod.Post)
            .WithUrl("pet")
            .WithJsonBody(petDto)
            .SendAsync<CreatePetResponseDto>(cancellationToken);
}
