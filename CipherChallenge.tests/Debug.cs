namespace CipherChallenge.tests;

public class Debug
{
    [Fact]
    public void UnitTestTest()
    {
        string expected = "Hello Word";
        string actual = CipherChallenge.Debug.UnitTestTest();
        Assert.Equal(expected, actual);
    }
}