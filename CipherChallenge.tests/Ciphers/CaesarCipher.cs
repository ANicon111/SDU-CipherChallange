namespace CipherChallenge.tests;

public class CaesarCipher
{
    [Fact]
    public void Encode()
    {
        string expected = "Vguv";
        string actual = new CipherChallenge.CaesarCipher { ShiftValue = 2 }.Encode("Test");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode()
    {
        string expected = "Test";
        string actual = new CipherChallenge.CaesarCipher { ShiftValue = 2 }.Decode("Vguv");
        Assert.Equal(expected, actual);
    }
}