using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Petstore.Api.Tests.Tests.Contexts;
using Reqnroll;

namespace Petstore.Api.Tests.Tests.StepDefinitions.CreatePet;

[Binding]
public class CreatePetThenSteps(CreatePetContext context)
{
    [Then("the API returns HTTP 200 with the submitted pet data")]
    public void ThenTheApiReturnsTheSubmittedPetData()
    {
        Assert.AreEqual(HttpStatusCode.OK, context.Response.StatusCode);

        var returnedPet = context.Response.Body;
        Assert.IsNotNull(returnedPet, "The response must contain a pet.");
        Assert.IsTrue(returnedPet.Id is > 0, "The response must include a positive pet ID.");
        Assert.AreEqual(context.SubmittedPet.Name, returnedPet.Name, "Unexpected pet name.");
        Assert.AreEqual(context.SubmittedPet.Status, returnedPet.Status, "Unexpected pet status.");
        CollectionAssert.AreEqual(context.SubmittedPet.PhotoUrls, returnedPet.PhotoUrls, "Unexpected photo URLs.");
    }
}
