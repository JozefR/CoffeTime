#### Previous: [Home &laquo;](../../../README.md)
[Test](../Factorial/package_fullBuild.binlog)

### Fibonacci

``` cs 
private static int Fibonacci(int x)
{
    if (x == 0)
        return 0;

    if (x == 1)
        return 1;

    return Fibonacci(x - 1) + Fibonacci(x - 2);
}
```

### Fibonacci dynamic

``` cs 
private static int FibonacciDynamic(int x, int[] helpArray)
{
    if (x == 0)
        return 0;

    if (x == 1)
        return 1;

    if (helpArray[x - 1] == 0)
    {
        helpArray[x - 1] = FibonacciDynamic(x - 1, helpArray);
    }

    if (helpArray[x - 2] == 0)
    {
        helpArray[x - 2] = FibonacciDynamic(x - 2, helpArray);
    }

    return helpArray[x - 1] + helpArray[x - 2];
}
```

### Fibonacci from down

``` cs 
private static int FibonacciFromDown(int x)
{
    var array = new int[x + 1];

    array[0] = 0;
    array[1] = 1;

    for (int i = 2; i <= x; i++)
    {
        array[i] = array[i - 1] + array[i - 2];
    }

    var result = array[x];

    return result;
}
```

#### Previous: [Home &laquo;](../../../README.md)
