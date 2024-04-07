namespace CipherChallenge.tests;

public class PlayfairCipher
{
    [Fact]
    public void Encode()
    {
        CipherChallenge.PlayfairCipher playfairCipher = new();
        playfairCipher.SetKeys(["MONARCHY"]);
        string expected = "Lktl";
        string actual = playfairCipher.Encode("Test");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode()
    {
        CipherChallenge.PlayfairCipher playfairCipher = new();
        playfairCipher.SetKeys(["MONARCHY"]);
        string expected = "Test";
        string actual = playfairCipher.Decode("Lktl");
        Assert.Equal(expected, actual);
    }
}