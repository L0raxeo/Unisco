using System.Collections.Generic;
using UnityEngine;

public static class Alphabet
{

    public static char getAdjacentChar(int currentChar, int incrementation)
    {
        Dictionary<int, char> alphabet = new Dictionary<int, char>();
        alphabet.Add(1, 'a');
        alphabet.Add(2, 'b');
        alphabet.Add(3, 'c');
        alphabet.Add(4, 'd');
        alphabet.Add(5, 'e');

        return alphabet[currentChar + incrementation];
    }

}
