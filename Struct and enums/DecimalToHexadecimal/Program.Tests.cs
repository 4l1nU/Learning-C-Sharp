using SeondApp;

public class TestProgram
{
    [Fact]
    public void HexadecimalTransformation_Number5_ShouldReturn5()
    {
        int decimalNumber = 5;
        Assert.Equal("5", Program.TransformFromDecimalToHexadecimal(decimalNumber));
    }

    [Fact]
    public void HexadecimalTransformation_Number10_ShouldReturnA()
    {
        int decimalNumber = 10;
        Assert.Equal("A", Program.TransformFromDecimalToHexadecimal(decimalNumber));
    }

    [Fact]
    public void HexadecimalTransformation_Number16_ShouldReturn10()
    {
        int decimalNumber = 16;
        Assert.Equal("10", Program.TransformFromDecimalToHexadecimal(decimalNumber));
    }

    [Fact]
    public void HexadecimalTransformation_Number43_ShouldReturn43()
    {
        int decimalNumber = 43;
        Assert.Equal("2B", Program.TransformFromDecimalToHexadecimal(decimalNumber));
    }

    [Fact]
    public void HexadecimalTransformation_Number123456789_ShouldReturn75BCD15()
    {
        int decimalNumber = 123456789;
        Assert.Equal("75BCD15", Program.TransformFromDecimalToHexadecimal(decimalNumber));
    }

    [Fact]
    public void HexadecimalTransformation_Number0_ShouldReturn0()
    {
        int decimalNumber = 0;
        Assert.Equal("0", Program.TransformFromDecimalToHexadecimal(decimalNumber));
    }
}