#### Previous: [Home &laquo;](../../README.md)

# Intro to Recursion

### Factorial

``` cs --region factorial --source-file .\Factorial\Program.cs --project .\Factorial\Factorial.csproj 
private static int FactorialFunc(int i)
{
    if (i == 1)
        return 1;

    return i * FactorialFunc(i - 1);
}

private static int WithoutRecursion(int number)
{
    int result = number;

    for (int i = number - 1; i > 0; i--)
    {
        result *= i;
    }

    return result;
}
```

### Palindrom

``` cs --region palindrom --source-file .\Palindrom\Program.cs --project .\Palindrom\Palindrom.csproj 
private static bool Palindrom(string rotor, int i)
{
    if (rotor.Length <= 1)
    {
        return true;
    }

    if (i == rotor.Length - i - 1)
    {
        return true;
    }

    if (rotor[i] != rotor[rotor.Length - i - 1])
        return false;

    return Palindrom(rotor, i + 1);
}

private static bool PalindromNonRecursion(string rotor)
{
    var result = "";

    for (int i = rotor.Length - 1; i >= 0; i--)
    {
        result += rotor[i];
    }

    if (result == rotor)
        return true;

    return false;
}
```

#### Previous: [Home &laquo;](../../README.md)