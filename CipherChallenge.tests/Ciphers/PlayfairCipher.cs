namespace CipherChallenge.tests;

public class PlayfairCipher
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