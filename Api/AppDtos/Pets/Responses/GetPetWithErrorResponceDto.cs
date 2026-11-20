using System.Net;

namespace AppDtos.Pets.Responses
{
    public class GetPetWithErrorResponceDto
    {
        public HttpStatusCode Code { get; set; }

        public string? Type { get; set; }

        public string? Message { get; set; }
    }
}
