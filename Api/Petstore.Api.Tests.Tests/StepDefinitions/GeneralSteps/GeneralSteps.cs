using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;
using System.Net;

namespace Petstore.Api.Tests.Tests.StepDefinitions.GeneralSteps;

[Binding]
public class GeneralSteps(ApiResponseMetadataContext responseMetadata)
{
    [Then("the API returns HTTP {int}")]
    public void ThenTheApiReturnsHttpStatus(int statusCode)
    {
        Assert.AreEqual((HttpStatusCode)statusCode, responseMetadata.StatusCode);
    }
}
