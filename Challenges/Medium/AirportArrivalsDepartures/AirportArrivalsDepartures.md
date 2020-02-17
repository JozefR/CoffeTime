#### Previous: [Home &laquo;](../Medium.md)

# Airport Arrivals Departures

[CodeWars](https://www.codewars.com/kata/57feb00f08d102352400026e/train/csharp)

You are at the airport staring blankly at the arrivals/departures flap display...

## How it works
You notice that each flap character is on some kind of a rotor and the order of characters on each rotor is:

    ABCDEFGHIJKLMNOPQRSTUVWXYZ ?!@#&()|<>.:=-+*/0123456789

And after a long while you deduce that the display works like this:

Starting from the left, all rotors (from the current one to the end of the line) flap together until the left-most rotor character is correct.
Then the mechanism advances by 1 rotor to the right...
...REPEAT this rotor procedure until the whole line is updated
...REPEAT this line procedure from top to bottom until the whole display is updated
Example
Consider a flap display with 3 rotors and one 1 line which currently spells CAT

    Step 1 (current rotor is 1)
    Flap x 1
    Now line says DBU

    Step 2 (current rotor is 2)
    Flap x 13
    Now line says DO)

    Step 3 (current rotor is 3)
    Flap x 27
    Now line says DOG

This can be represented as

1. lines  // array of strings. Each string is a display line of the initial configuration
2. rotors // array of array-of-rotor-values. Each array-of-rotor-values is applied to the corresponding display line
3. result // array of strings. Each string is a display line of the final configuration e.g.

        lines = ["CAT"]
        rotors = [[1,13,27]]
        result = ["DOG"]


Kata Task
Given the initial display lines and the rotor moves for each line, determine what the board will say after it has been fully updated.

For your convenience the characters of each rotor are in the pre-loaded constant ALPHABET which is a string.

## Solution

## Solutions

``` cs  
public static string[] FlapDisplay(string[] lines, int[][] rotors)
{
    string[] result = new String[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
        string rotatedResult = "";
        int rotatedRotors = 0;

        for (int j = 0; j < lines[i].Length; j++)
        {
            rotatedRotors += rotors[i][j];
            var characterToRotate = lines[i][j];
            var startIndex = ALPHABET.IndexOf(characterToRotate);
            var newIndex = startIndex + rotatedRotors;

            if (newIndex < ALPHABET.Length)
            {
                var newChar = ALPHABET[newIndex];
                rotatedResult += newChar;
                continue;
            }

            while (newIndex >= ALPHABET.Length)
            {
                newIndex -= ALPHABET.Length;
            }

            var newChar2 = ALPHABET[newIndex];
            rotatedResult += newChar2;
        }

        result[i] = rotatedResult;
    }

    return result;
}
```

### Refactored

``` cs  
public static string[] FlapDisplay(string[] lines, int[][] rotors)
{
    string[] result = new String[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
        string rotatedResult = "";
        int rotorsSum = 0;

        for (int j = 0; j < lines[i].Length; j++)
        {
            rotorsSum += rotors[i][j];
            var oldCharacter = lines[i][j];

            var newCharacter = Rotation(oldCharacter, rotorsSum);

            rotatedResult += newCharacter;
        }

        result[i] = rotatedResult;
    }

    return result;
}

private static char Rotation(in char oldCharacter, int rotorsSum)
{
    var startFromIndex = ALPHABET.IndexOf(oldCharacter);
    var rotation = (startFromIndex + rotorsSum) % ALPHABET.Length;
    return ALPHABET[rotation];
}
```

### Clever

``` cs
public static string[] FlapDisplay2(String[] lines, int[][] rotors)
{
    for (int l = 0; l < lines.Length; l++)
    for (int i = 0; i < lines[l].Length; i++)
    for (int k = i; k < lines[l].Length; k++)
        lines[l] = lines[l].Remove(k, 1).Insert(k, lines[l][k].Rotate(rotors[l][i]));
    return lines;
}

public static class CharExtension
{
    private static string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ?!@#&()|<>.:=-+*/0123456789";

    public static string Rotate(this char c, int rotor)
    {
        int position = ALPHABET.IndexOf(c) + rotor;
        while (position >= ALPHABET.Length)
            position -= ALPHABET.Length;
        return "" + ALPHABET[position];
    }
}
```

#### Previous: [Home &laquo;](../Medium.md)
