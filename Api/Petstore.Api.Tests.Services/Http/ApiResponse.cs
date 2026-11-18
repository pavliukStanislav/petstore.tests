using System.Net;

namespace Petstore.Api.Tests.Services.Http;

public class ApiResponse<T>
{
    public HttpStatusCode StatusCode { get; init; }

    public T? Body { get; init; }
}
