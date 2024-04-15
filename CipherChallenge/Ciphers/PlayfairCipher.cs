using System.Collections.Generic;
using System.Linq;

namespace CipherChallenge;

class PlayfairCipher() : ICipher
{
    public string Name => "Playfair";

    public Dictionary<string, string> KeyNamesAndDefaultValues => new(){
        {"Keyword",""}
    };
    internal readonly char[,] KeyTable = new char[5, 5];

    private (int, int) LetterPosition(char c)
    {
        for (int i = 0; i < 25; i++)
        {
            if (c == KeyTable[i % 5, i / 5]) return (i % 5, i / 5);
        }
        return (-1, -1);
    }


    public string Decode(string encodedText)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        List<char> letters = [];
        List<char> originalWithPlaceholders = [];
        foreach (char character in encodedText)
        {
            char c = char.ToUpper(character);
            if (alphabet.Contains(c))
            {
                if (c == 'J') c = 'I';
                if (letters.Count % 2 == 1 && c == letters.LastOrDefault('0'))
                {
                    if (c == 'X')
                    {
                        letters.Add('Q');
                    }
                    else
                    {
                        letters.Add('X');
                    }
                    originalWithPlaceholders.Add('J');
                }
                letters.Add(c);
                originalWithPlaceholders.Add(char.IsUpper(character) ? 'J' : 'j');
            }
            else
            {
                originalWithPlaceholders.Add(character);
            }
        }

        if (letters.Count % 2 == 1)
        {
            if (letters[^1] == 'X')
            {
                letters.Add('Q');
            }
            else
            {
                letters.Add('X');
            }
            originalWithPlaceholders.Add('J');
        }

        for (int i = 0; i < letters.Count; i += 2)
        {
            (int aX, int aY) = LetterPosition(letters[i]);
            (int bX, int bY) = LetterPosition(letters[i + 1]);
            if (aX == bX) (aY, bY) = ((aY + 4) % 5, (bY + 4) % 5);
            else if (aY == bY) (aX, bX) = ((aX + 4) % 5, (bX + 4) % 5);
            else (aX, bX) = (bX, aX);
            letters[i] = KeyTable[aX, aY];
            letters[i + 1] = KeyTable[bX, bY];
        }

        for (int i = 0, j = 0; i < originalWithPlaceholders.Count; i++)
        {
            if (originalWithPlaceholders[i] == 'J')
            {
                originalWithPlaceholders[i] = letters[j++];
            }
            if (originalWithPlaceholders[i] == 'j')
            {
                originalWithPlaceholders[i] = char.ToLower(letters[j++]);
            }
        }

        return new([.. originalWithPlaceholders]);
    }

    public string Encode(string plainText)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        List<char> letters = [];
        List<char> originalWithPlaceholders = [];
        foreach (char character in plainText)
        {
            char c = char.ToUpper(character);
            if (alphabet.Contains(c))
            {
                if (c == 'J') c = 'I';
                if (letters.Count % 2 == 1 && c == letters.LastOrDefault('0'))
                {
                    if (c == 'X')
                    {
                        letters.Add('Q');
                    }
                    else
                    {
                        letters.Add('X');
                    }
                    originalWithPlaceholders.Add('J');
                }
                letters.Add(c);
                originalWithPlaceholders.Add(char.IsUpper(character) ? 'J' : 'j');
            }
            else
            {
                originalWithPlaceholders.Add(character);
            }
        }

        if (letters.Count % 2 == 1)
        {
            if (letters[^1] == 'X')
            {
                letters.Add('Q');
            }
            else
            {
                letters.Add('X');
            }
            originalWithPlaceholders.Add('J');
        }

        for (int i = 0; i < letters.Count; i += 2)
        {
            (int aX, int aY) = LetterPosition(letters[i]);
            (int bX, int bY) = LetterPosition(letters[i + 1]);
            if (aX == bX) (aY, bY) = ((aY + 1) % 5, (bY + 1) % 5);
            else if (aY == bY) (aX, bX) = ((aX + 1) % 5, (bX + 1) % 5);
            else (aX, bX) = (bX, aX);
            letters[i] = KeyTable[aX, aY];
            letters[i + 1] = KeyTable[bX, bY];
        }

        for (int i = 0, j = 0; i < originalWithPlaceholders.Count; i++)
        {
            if (originalWithPlaceholders[i] == 'J')
            {
                originalWithPlaceholders[i] = letters[j++];
            }
            if (originalWithPlaceholders[i] == 'j')
            {
                originalWithPlaceholders[i] = char.ToLower(letters[j++]);
            }
        }

        return new([.. originalWithPlaceholders]);
    }

    public string? SetKeys(List<string> keyStrings)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        foreach (char c in keyStrings[0])
            if (!alphabet.Contains(c))
                return "Invalid keyword; You may only use capital letters of the english alphabet";
        string alphabetNoJ = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        string keyword = keyStrings[0].Trim().ToUpper();
        for (int i = 0; i < 25; i++)
        {
            if (keyword.Length > 0)
            {
                KeyTable[i % 5, i / 5] = keyword[0];
                alphabetNoJ = alphabetNoJ.Replace($"{keyword[0]}", "");
                keyword = keyword.Replace($"{keyword[0]}", "");
            }
            else
            {
                KeyTable[i % 5, i / 5] = alphabetNoJ[0];
                alphabetNoJ = alphabetNoJ[1..];
            }
        }
        return null;
    }

}