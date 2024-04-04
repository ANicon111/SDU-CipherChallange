namespace CipherChallenge.tests;

public class DoubleTranspositionCipher //TODO
{
    [Fact]
    public void Encode()
    {
        string expected = "";
        string actual = "Test";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode()
    {
        string expected = "Test";
        string actual = "";
        Assert.Equal(expected, actual);
    }
}