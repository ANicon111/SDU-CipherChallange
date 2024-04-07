using System.Collections.Generic;

namespace CipherChallenge;

class AtbashCipher() : ICipher
{
    public string Name => "Atbash";

    public Dictionary<string, string> KeyNamesAndDefaultValues => [];

    public string? SetKeys(List<string> keyStrings) => null;

    public string Encode(string plainText)
    {
        char[] encodedText = new char[plainText.Length];
        for (int i = 0; i < plainText.Length; i++)
        {
            if ('A' <= plainText[i] && plainText[i] <= 'Z')
                encodedText[i] = (char)('Z' + 'A' - plainText[i]);
            else if ('a' <= plainText[i] && plainText[i] <= 'z')
                encodedText[i] = (char)('z' + 'a' - plainText[i]);
            else
                encodedText[i] = plainText[i];
        }
        return new(encodedText);
    }

    public string Decode(string plainText) => Encode(plainText); //lol

}