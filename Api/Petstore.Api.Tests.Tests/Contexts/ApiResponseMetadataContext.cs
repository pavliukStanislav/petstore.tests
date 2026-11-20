using System.Net;

namespace Petstore.Api.Tests.Tests.Contexts;

public class ApiResponseMetadataContext
{
    public HttpStatusCode? StatusCode { get; set; }
}