using System.Collections.Generic;

namespace CipherChallenge;

class AtbashCipher() : ICipher
{
    public string Name => "Atbash";

    public Dictionary<string, string> KeyNamesAndDefaultValues => [];

    public string? SetKeys(List<string> keyStrings) => null;

    public string Decode(string encodedText)
    {
        char[] decodedText = new char[encodedText.Length];
        for (int i = 0; i < encodedText.Length; i++)
        {
            if ('A' <= encodedText[i] && encodedText[i] <= 'Z')
                decodedText[i] = (char)('Z' + 'A' - encodedText[i]);
            else if ('a' <= encodedText[i] && encodedText[i] <= 'z')
                decodedText[i] = (char)('z' + 'a' - encodedText[i]);
            else
                decodedText[i] = encodedText[i];
        }
        return new(decodedText);
    }

    public string Encode(string plainText) => Decode(plainText); //lol

}