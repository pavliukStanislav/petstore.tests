using AppDtos.Pets.Requests;
using AppDtos.Pets.Responses;
using Petstore.Api.Tests.Services.Http;

namespace Petstore.Api.Tests.Services.Pets;

public class PetsService
{
    public Task<ApiResponse<CreatePetResponseDto>> CreatePetAsync(
        CreatePetRequestDto petDto, CancellationToken cancellationToken = default)
        => new PetstoreRequestBuilder()
            .WithMethod(HttpMethod.Post)
            .WithUrl("pet")
            .WithJsonBody(petDto)
            .SendAsync<CreatePetResponseDto>(cancellationToken);

    public Task<ApiResponse<GetPetResponseDto>> GetPetAsync(
        string petId, CancellationToken cancellationToken = default)
        => new PetstoreRequestBuilder()
            .WithMethod(HttpMethod.Get)
            .WithUrl($"pet/{petId}")
            .SendAsync<GetPetResponseDto>(cancellationToken);

    public Task<ApiResponse<GetPetWithErrorResponceDto>> GetPetWithErrorAsync(
        string petId, CancellationToken cancellationToken = default)
        => new PetstoreRequestBuilder()
            .WithMethod(HttpMethod.Get)
            .WithUrl($"pet/{petId}")
            .SendAsync<GetPetWithErrorResponceDto>(cancellationToken);

    public Task<ApiResponse<DeletePerResponceDto>> DeletePetAsync(
        string petId, CancellationToken cancellationToken = default)
        => new PetstoreRequestBuilder()
            .WithMethod(HttpMethod.Delete)
            .WithUrl($"pet/{petId}")
            .SendAsync<DeletePerResponceDto>(cancellationToken);

    public Task<ApiResponse<string>> DeletePetWithErrorAsync(
        string petId, CancellationToken cancellationToken = default)
        => new PetstoreRequestBuilder()
            .WithMethod(HttpMethod.Delete)
            .WithUrl($"pet/{petId}")
            .SendAsync<string>(cancellationToken);
}
