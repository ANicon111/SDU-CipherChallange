using System.Collections.Generic;

namespace CipherChallenge;

class CaesarCipher() : ICipher
{
    public string Name => "Caesar";

    public Dictionary<string, string> KeyNamesAndDefaultValues => new(){
        {"Shift Number",""}
    };

    private static readonly int alphabetLength = 'Z' - 'A' + 1;
    internal int ShiftValue = 0;

    public string? SetKeys(List<string> keyStrings)
    {
        if (!int.TryParse(keyStrings[0], out ShiftValue)) return "Invalid shift number";
        return null;
    }

    public string Encode(string encodedText)
    {

        char[] decodedText = new char[encodedText.Length];
        for (int i = 0; i < encodedText.Length; i++)
        {
            bool capitalized;
            int characterValue;
            if ('A' <= encodedText[i] && encodedText[i] <= 'Z')
            {
                capitalized = true;
                characterValue = encodedText[i] - 'A';
            }
            else if ('a' <= encodedText[i] && encodedText[i] <= 'z')
            {
                capitalized = false;
                characterValue = encodedText[i] - 'a';
            }
            else
            {
                capitalized = false;
                characterValue = -1;
            }
            //normalize ShiftValue to between 0 and alphabetLength
            ShiftValue = (ShiftValue % alphabetLength + alphabetLength) % alphabetLength;
            if (characterValue == -1)
                decodedText[i] = encodedText[i];
            else
                decodedText[i] = (char)((capitalized ? 'A' : 'a') + (characterValue + ShiftValue) % alphabetLength);
        }
        return new(decodedText);
    }

    public string Decode(string plainText)
    {
        ShiftValue = -ShiftValue;
        string encodedText = Encode(plainText);
        ShiftValue = -ShiftValue;
        return encodedText;
    } //lol

}