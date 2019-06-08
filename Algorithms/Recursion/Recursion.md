#### Previous: [Home &laquo;](../../README.md)

# Intro to Recursion

### Binary search

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

#### Previous: [Home &laquo;](../../README.md)