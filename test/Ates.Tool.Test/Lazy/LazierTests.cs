namespace SmartInventory.Application.Test.Tools.Lazy;

using Ates.Tool.Lazy;

public class LazierTests
{
    [Fact]
    public void Lazier_New()
    {
        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider.Setup(s => s.GetService(typeof(TestClass))).Returns(new TestClass());
        var lazier = new Lazier<TestClass>(serviceProvider.Object);
        Assert.IsType<TestClass>(lazier.Value);
    }

    /// <summary>
    /// Service için boş test class
    /// </summary>
    private class TestClass
    {
    }
}


