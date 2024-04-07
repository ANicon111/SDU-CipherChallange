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
    internal int[] ReverseOrder1 = [];
    internal List<Tuple<char, int>> Order2 = [];
    internal int[] ReverseOrder2 = [];

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
        for (int i = 0; i < keyStrings[0].Length; i++)
            if (!alphabetOrNumbers.Contains(keyStrings[0][i]))
                return "Invalid first key; You may only use letters of the english alphabet or numbers";
            else
                Order1.Add(new(keyStrings[0][i], i));
        Order1.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        ReverseOrder1 = new int[Order1.Count];
        for (int i = 0; i < Order1.Count; i++) ReverseOrder1[Order1[i].Item2] = i;


        Order2 = [];
        for (int i = 0; i < keyStrings[1].Length; i++)
            if (!alphabetOrNumbers.Contains(keyStrings[1][i]))
                return "Invalid second key; You may only use letters of the english alphabet or numbers";
            else
                Order2.Add(new(keyStrings[1][i], i));
        Order2.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        ReverseOrder2 = new int[Order2.Count];
        for (int i = 0; i < Order2.Count; i++) ReverseOrder2[Order2[i].Item2] = i;

        return "";
    }
}