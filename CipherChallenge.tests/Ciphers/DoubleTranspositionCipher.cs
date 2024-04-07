namespace CipherChallenge.tests;

public class DoubleTranspositionCipher
{
    [Fact]
    public void Encode()
    {
        CipherChallenge.DoubleTranspositionCipher doubleTranspositionCipher = new();
        doubleTranspositionCipher.SetKeys(["3142", "24135"]);
        string expected = "Test";
        string actual = doubleTranspositionCipher.Encode("Test");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode()
    {
        CipherChallenge.DoubleTranspositionCipher doubleTranspositionCipher = new();
        doubleTranspositionCipher.SetKeys(["3142", "24135"]);
        string expected = "Test";
        string actual = doubleTranspositionCipher.Decode("Test");
        Assert.Equal(expected, actual);
    }
}