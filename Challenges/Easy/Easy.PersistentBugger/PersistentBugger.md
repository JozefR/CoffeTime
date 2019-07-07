#### Previous: [Home &laquo;](../EasyChallenges.md)

# Persistent Bugger

[Codewars](https://www.codewars.com/kata/persistent-bugger)

Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, which is the number of times you must multiply the digits in num until you reach a single digit.

     persistence(39) == 3 // because 3*9 = 27, 2*7 = 14, 1*4=4
                          // and 4 has only one digit
    
     persistence(999) == 4 // because 9*9*9 = 729, 7*2*9 = 126,
                           // 1*2*6 = 12, and finally 1*2 = 2
    
     persistence(4) == 0 // because 4 is already a one-digit number
    
### Solutions
    
``` cs  
public static long Persistence(long n)
{
    // 1. convert to string
    // 2. iterate over characters
    // 3. each char convert back to long and multiple all of them => result
    // 4. If string lengh greater then 1 continue to point 1.
    // 5. Return result.
    var chars = n.ToString();
    long result = 0;

    while (chars.Length > 1)
    {
        long multiplication = int.Parse(chars[0].ToString());

        for (int i = 1; i < chars.Length; i++)
        {
            multiplication *= int.Parse(chars[i].ToString());
        }

        chars = multiplication.ToString();
        result++;
    }

    return result;
}

public static int Persistence1(long n)
{
    int count = 0;
    while (n > 9)
    {
        count++;
        n = n.ToString().Select(digit => int.Parse(digit.ToString())).Aggregate((x, y) => x * y);
    }
    return count;
}

public static int Persistence2(long n)
{
    int count = 0;

    string number = n.ToString();
    while(number.Length > 1)
    {
        n = 1;
        Array.ForEach(number.ToArray(), c => n = n * (long)Char.GetNumericValue(c));
        number = n.ToString();
        count++;
    }

    return count;
}

```

#### Previous: [Home &laquo;](../Medium.md)
