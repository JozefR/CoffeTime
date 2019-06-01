#### Previous: [Home &laquo;](../../README.md)

# Intro to Sorting Algorithms

### Selection Sort

``` cs --region selectionSort --source-file .\SelectionSort\Program.cs --project .\SelectionSort\SelectionSort.csproj 
private static int[] selectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++) // (n - 1)
    {
        int minimum = array[i];
        int minimumIndex = i;

        for (int j = minimumIndex + 1; j < array.Length; j++) // (n - i)
        {
            if (minimum > array[j])
            {
                minimum = array[j];
                minimumIndex = j;
            }
        }
        Swap(array, i, minimumIndex); // O(1)
    }
    return array;
}
```

### Insertion Sort

``` cs --region insertionSort --source-file .\InsertionSort\Program.cs --project .\InsertionSort\InsertionSort.csproj 
for (int i = 0; i < array.Length; i++)
{
    var key = array[i];
    var leftIndex = i - 1;

    while (leftIndex > 0 && array[leftIndex] > key)
    {
        array[leftIndex + 1] = array[leftIndex];
        leftIndex -= 1;
    }

    array[leftIndex + 1] = key;
}

return array;
```

#### Previous: [Home &laquo;](../../README.md)
