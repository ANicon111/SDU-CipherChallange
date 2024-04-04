using System.Collections.Generic;

namespace CipherChallenge;

class PlayfairCipher() : ICipher
{
    public string Name => "Playfair";

    public Dictionary<string, string> KeyNamesAndDefaultValues => throw new System.NotImplementedException();

    public string Decode(string encodedText)
    {
        throw new System.NotImplementedException();
    }

    public string Encode(string plainText)
    {
        throw new System.NotImplementedException();
    }

    public string? SetKeys(List<string> keyStrings)
    {
        throw new System.NotImplementedException();
    }
}