#### Previous: [Home &laquo;](../Medium.md)

# IP Validation

[Codewars](https://www.codewars.com/kata/ip-validation)

Write an algorithm that will identify valid IPv4 addresses in dot-decimal format. 
IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.

Input to the function is guaranteed to be a single string.

Examples
Valid inputs:
    
    1.2.3.4
    123.45.67.89
    
Invalid inputs:

    1.2.3
    1.2.3.4.5
    123.456.78.90
    123.045.067.089
    
Note that leading zeros (e.g. 01.02.03.04) are considered invalid.

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

#### Previous: [Home &laquo;](../Medium.md)
