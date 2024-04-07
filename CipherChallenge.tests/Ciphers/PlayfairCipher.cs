namespace CipherChallenge.tests;

public class PlayfairCipher
{
    [Fact]
    public void Encode()
    {
        CipherChallenge.PlayfairCipher playfairCipher = new();
        playfairCipher.SetKeys(["MONARCHY"]);
        string expected = "LKTL";
        string actual = playfairCipher.Encode("TEST");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode()
    {
        CipherChallenge.PlayfairCipher playfairCipher = new();
        playfairCipher.SetKeys(["MONARCHY"]);
        string expected = "TEST";
        string actual = playfairCipher.Decode("LKTL");
        Assert.Equal(expected, actual);
    }
}