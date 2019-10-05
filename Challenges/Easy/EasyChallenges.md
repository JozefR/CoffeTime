#### Previous: [Home &laquo;](../../README.md)

# Easy

- [PersistentBugger](././Easy.PersistentBugger/PersistentBugger.md)

### Biggest of three
``` cs  
private static int BiggestOfThree(int A, int B, int C)
{
    int biggest = 0;

    if (A > B)
    {
        if (A > C)
            biggest = A;
        else
            biggest = C;
    }
    else
    {
        if (B > C)
            biggest = B;
        else
            biggest = C;
    }

    return biggest;
}
```

### Find Median

``` cs  
private static int FindMedian(int[] array)
{
    if (array.Length == 0)
        throw new Exception("empty");

    Array.Sort(array);
    int median;

    if (array.Length % 2 == 0)
    {
        int middle1 = array[array.Length / 2] - 1;
        int middle2 = array[array.Length / 2];
        median = (middle1 + middle2) / 2;
    }
    else
    {
        median = array[array.Length / 2];
    }

    return median;
}
```     

### Dubstep

[Codewars](https://www.codewars.com/kata/dubstep/train/csharp)

Extract WUB substrings from a string.

Example:

    songDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB")
    // =>  WE ARE THE CHAMPIONS MY FRIEND

Solution:

``` cs    
public static string SongDecoder(string input)
{
    var stringWhite = input.Replace("WUB", " ").Trim();
    return Regex.Replace(stringWhite, @"\s+", " ");
}

public static string SongDecoder2(string input)
{
    return String.Join(" ", new string[] {"WUB"}, StringSplitOptions.RemoveEmptyEntries);
}     
``` 

#### Previous: [Home &laquo;](../../README.md)
