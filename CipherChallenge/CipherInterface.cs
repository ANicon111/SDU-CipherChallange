using System;
using System.Collections.Generic;

namespace CipherChallenge;

public interface ICipher
{
    //stores the cipher name
    string Name { get; }

    //stores the key names and default values
    Dictionary<string, string> KeyNamesAndDefaultValues { get; }

    //returns a key that is invalid, or null if everything is valid
    string? SetKeys(List<string> keyStrings);

    //returns the encoded value
    string Encode(string plainText);

    //returns the decoded value
    string Decode(string encodedText);
}