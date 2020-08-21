using Xunit;
using Bunit;
using OrderManagement.UI.Components;
namespace OrderManagement.Client.Tests
{
  public class HelloWorldImplicitContextTest : TestContext
  {
    [Fact]
    public void HelloWorldComponentRendersCorrectly()
    {
      // Act
      var cut = RenderComponent<HelloWorld>();

      // Assert
      cut.MarkupMatches("<h3>Hello world !</h3>");
    }
  }
}