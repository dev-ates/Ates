namespace SmartInventory.Application.Test.Tools.RandomString;

using Ates.Tool.RandomString;

public class RandomStringToolTests
{
    private readonly IRandomStringTool randomStringTool;

    public RandomStringToolTests()
    {
        this.randomStringTool = new RandomStringTool();
    }

    [Theory]
    [InlineData(0)]
    public void RandomString_Empty_Zero(Int32 length)
    {
        Assert.Equal(String.Empty, this.randomStringTool.RandomString(length));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(Int32.MaxValue / 1000)]
    public void RandomString_PossitiveLength(Int32 length)
    {
        Assert.Equal(length, this.randomStringTool.RandomString(length).Length);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(Int32.MinValue / 1000)]
    public void RandomString_NegativeLength_ArgumentOutOfRangeException(Int32 length)
    {
        var result = Record.Exception(() => Assert.Equal(length, this.randomStringTool.RandomString(length).Length));
        Assert.NotNull(result);
        var exception = Assert.IsType<ArgumentOutOfRangeException>(result);
        var actual = exception.ParamName;
        const String expected = "length";
        Assert.Equal(expected, actual);
    }
}
