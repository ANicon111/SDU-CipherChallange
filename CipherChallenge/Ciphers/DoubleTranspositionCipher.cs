using System;
using System.Collections.Generic;
using System.Linq;

namespace CipherChallenge;

class DoubleTranspositionCipher() : ICipher
{
    public string Name => "Double Transposition";

    public Dictionary<string, string> KeyNamesAndDefaultValues => new(){
        {"First key",""},
        {"Second key",""}
    };

    internal List<Tuple<char, int>> Order1 = [];
    internal List<Tuple<char, int>> Order2 = [];

    //Good luck understanding this code. I learned this design in my highschool c++ phase >:]
    public string Decode(string encodedText)
    {
        char[] firstDecoded = new char[encodedText.Length];
        int firstW = Order2.Count;
        int firstH = encodedText.Length / firstW + ((encodedText.Length % firstW) == 0 ? 0 : 1);
        for (int i = 0, j = 0, formula; i < firstW * firstH; i++)
        {
            formula = i % firstH * firstW + Order2[i / firstH].Item2;
            if (formula < encodedText.Length)
                firstDecoded[formula] = encodedText[j++];
        }

        char[] secondDecoded = new char[firstDecoded.Length];
        int secondW = Order1.Count;
        int secondH = firstDecoded.Length / secondW + ((firstDecoded.Length % secondW) == 0 ? 0 : 1);
        for (int i = 0, j = 0, formula; i < secondW * secondH; i++)
        {
            formula = i % secondH * secondW + Order1[i / secondH].Item2;
            if (formula < firstDecoded.Length)
                secondDecoded[formula] = firstDecoded[j++];
        }

        return new(secondDecoded);
    }

    public string Encode(string plainText)
    {
        char[] firstEncoded = new char[plainText.Length];
        int firstW = Order1.Count;
        int firstH = plainText.Length / firstW + ((plainText.Length % firstW) == 0 ? 0 : 1);
        for (int i = 0, j = 0, formula; i < firstW * firstH; i++)
        {
            formula = i % firstH * firstW + Order1[i / firstH].Item2;
            if (formula < plainText.Length)
                firstEncoded[j++] = plainText[formula];
        }

        char[] secondEncoded = new char[firstEncoded.Length];
        int secondW = Order2.Count;
        int secondH = firstEncoded.Length / secondW + ((firstEncoded.Length % secondW) == 0 ? 0 : 1);
        for (int i = 0, j = 0, formula; i < secondW * secondH; i++)
        {
            formula = i % secondH * secondW + Order2[i / secondH].Item2;
            if (formula < firstEncoded.Length)
                secondEncoded[j++] = firstEncoded[formula];
        }

        return new(secondEncoded);
    }

    public string? SetKeys(List<string> keyStrings)
    {
        string alphabetOrNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        Order1 = [];
        string firstKeyString = keyStrings[0].ToUpper();
        for (int i = 0; i < firstKeyString.Length; i++)
            if (!alphabetOrNumbers.Contains(firstKeyString[i]))
                return "Invalid first key; You may only use letters of the english alphabet or numbers";
            else
                Order1.Add(new(firstKeyString[i], i));
        Order1 = [.. Order1.OrderBy((a) => a.Item1)];


        Order2 = [];
        string secondKeyString = keyStrings[1].ToUpper();
        for (int i = 0; i < secondKeyString.Length; i++)
            if (!alphabetOrNumbers.Contains(secondKeyString[i]))
                return "Invalid second key; You may only use letters of the english alphabet or numbers";
            else
                Order2.Add(new(secondKeyString[i], i));
        Order2 = [.. Order2.OrderBy((a) => a.Item1)];

        return null;
    }
}