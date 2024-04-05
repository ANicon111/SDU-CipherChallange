namespace CipherChallenge.tests;

public class AtbashCipher
{
    [Fact]
    public void Encode()
    {
        string expected = "Gvhg";
        string actual = new CipherChallenge.AtbashCipher().Decode("Test");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode()
    {
        string expected = "Test";
        string actual = new CipherChallenge.AtbashCipher().Decode("Gvhg");
        Assert.Equal(expected, actual);
    }
}