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

#### Previous: [Home &laquo;](../../README.md)
